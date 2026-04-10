using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BoardBackgroundController : MonoBehaviour
{
    [SerializeField] private float overscan = 1.12f;
    [SerializeField] private float horizontalSpeed = 0.08f;
    [SerializeField] private float verticalSpeed = 0.05f;
    [SerializeField] private float horizontalTravel = 0.45f;
    [SerializeField] private float verticalTravel = 0.3f;

    private SpriteRenderer spriteRenderer;
    private Camera cachedCamera;
    private Vector3 baseLocalPosition;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseLocalPosition = transform.localPosition;
        cachedCamera = Camera.main;
    }

    private void OnEnable()
    {
        RefreshLayout();
    }

    private void LateUpdate()
    {
        if (spriteRenderer == null || spriteRenderer.sprite == null) return;

        Camera activeCamera = cachedCamera != null ? cachedCamera : Camera.main;
        if (activeCamera == null || !activeCamera.orthographic) return;

        RefreshLayout();

        float viewHeight = activeCamera.orthographicSize * 2f;
        float viewWidth = viewHeight * activeCamera.aspect;
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        float scaledWidth = spriteSize.x * transform.localScale.x;
        float scaledHeight = spriteSize.y * transform.localScale.y;

        float maxOffsetX = Mathf.Max(0f, (scaledWidth - viewWidth) * 0.5f) * horizontalTravel;
        float maxOffsetY = Mathf.Max(0f, (scaledHeight - viewHeight) * 0.5f) * verticalTravel;

        float offsetX = Mathf.Sin(Time.unscaledTime * horizontalSpeed) * maxOffsetX;
        float offsetY = Mathf.Cos(Time.unscaledTime * verticalSpeed) * maxOffsetY;

        transform.localPosition = new Vector3(baseLocalPosition.x + offsetX, baseLocalPosition.y + offsetY, baseLocalPosition.z);
    }

    public void RefreshLayout()
    {
        if (spriteRenderer == null || spriteRenderer.sprite == null) return;

        Camera activeCamera = cachedCamera != null ? cachedCamera : Camera.main;
        if (activeCamera == null || !activeCamera.orthographic) return;

        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
        if (spriteSize.x <= 0f || spriteSize.y <= 0f) return;

        float viewHeight = activeCamera.orthographicSize * 2f;
        float viewWidth = viewHeight * activeCamera.aspect;

        float scale = Mathf.Max(viewWidth / spriteSize.x, viewHeight / spriteSize.y) * overscan;
        transform.localScale = new Vector3(scale, scale, 1f);
    }
}
