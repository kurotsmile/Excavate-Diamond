using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Handle : MonoBehaviour
{
    public Carrot.Carrot carrot;
    public IronSourceAds ads;

    public GameObject panel_main;
    public GameObject panel_play;
    public GameObject panel_gameover;
    private bool is_play = false;

    [Header("Obj game")]
    public GameObject obj_main_board_bk;
    public Sprite[] backgroundSprites;
    public ScoreManager score;
    public BoardManager board_diamo;

    [Header("Timer Game")]
    public Text txt_timer;
    public int duration;
    private float time;

    [Header("GameOver")]
    public Text txt_gameover_socre_you;
    public Text txt_gameover_socre_hight;

    [Header("Effect Game")]
    public GameObject[] effect_prefab;
    public AudioSource[] sounds;

    void Start()
    {
        this.is_play = false;
        this.ensure_background_controller();
        this.apply_random_background();
        this.obj_main_board_bk.SetActive(true);
        this.carrot.Load_Carrot();
        this.ads.On_Load();
        this.panel_main.SetActive(true);
        this.panel_play.SetActive(false);
        this.panel_gameover.SetActive(false);
        this.score.load();
        this.board_diamo.reset();
        this.carrot.game.load_bk_music(this.sounds[0]);
    }

    public void btn_play_game()
    {
        this.ads.show_ads_Interstitial();
        this.carrot.play_sound_click();
        this.carrot.clear_contain(this.board_diamo.transform);
        this.board_diamo.reset();
        this.is_play = true;
        this.time = 0f;
        this.score.ResetCurrentScore();
        this.ensure_background_controller();
        this.apply_random_background();
        this.obj_main_board_bk.SetActive(true);
        this.panel_play.SetActive(true);
        this.panel_main.SetActive(false);
        this.panel_gameover.SetActive(false);
    }

    public void btn_show_setting_game()
    {
        this.is_play = false;
        this.carrot.play_sound_click();
        Carrot.Carrot_Box box_setting = this.carrot.Create_Setting();
        box_setting.set_act_before_closing(after_close_setting);
    }

    private void after_close_setting(IList s_item_setting_change)
    {
        foreach (string s in s_item_setting_change)
        {
            if (s == "list_bk_music") this.carrot.game.load_bk_music(this.sounds[0]);
        }
        if (this.panel_play.activeInHierarchy) this.is_play = true;
        this.ads.show_ads_Interstitial();
    }

    public void btn_back_home()
    {
        this.ads.show_ads_Interstitial();
        this.is_play = false;
        this.carrot.play_sound_click();
        this.panel_main.SetActive(true);
        this.panel_play.SetActive(false);
        this.panel_gameover.SetActive(false);
    }

    void Update()
    {
        if (this.is_play)
        {
            if (time > duration)
            {
                this.show_gameover();
                return;
            }
            txt_timer.text = GetTimeString(this.GetRemainingTime() + 1);
            time += Time.deltaTime;
        }
    }

    public void show_gameover()
    {
        this.is_play = false;
        this.score.SetHighScore();
        this.txt_gameover_socre_hight.text = "High Socers:" + this.score.get_HighScore().ToString();
        this.txt_gameover_socre_you.text = "Current Score:" + this.score.get_currentScore().ToString();
        this.panel_gameover.SetActive(true);
        this.panel_play.SetActive(false);
        this.carrot.game.update_scores_player(this.score.get_currentScore());
        this.carrot.play_vibrate();
    }

    public void btn_show_user_login()
    {
        this.carrot.play_sound_click();
        this.carrot.user.show_login();
    }

    public void btn_show_rate()
    {
        this.carrot.play_sound_click();
        this.carrot.show_rate();
    }

    public void btn_show_share()
    {
        this.carrot.play_sound_click();
        this.carrot.show_share();
    }

    public void btn_show_top_player()
    {
        this.carrot.play_sound_click();
        this.carrot.game.Show_List_Top_player();
    }

    private float GetRemainingTime()
    {
        return duration - time;
    }

    private string GetTimeString(float timeRemaining)
    {
        int minute = Mathf.FloorToInt(timeRemaining / 60);
        int second = Mathf.FloorToInt(timeRemaining % 60);

        return string.Format("{0} : {1}", minute.ToString(), second.ToString());
    }

    public bool get_status_play()
    {
        return this.is_play;
    }

    public void create_effect()
    {
        GameObject obj_effect = Instantiate(this.effect_prefab[0]);
        obj_effect.transform.SetParent(this.panel_play.transform);
        obj_effect.transform.position = new Vector3(obj_effect.transform.position.x, obj_effect.transform.position.y, obj_effect.transform.position.z);
        obj_effect.transform.localScale = new Vector3(1f, 1f, 1f);
        Destroy(obj_effect, 1.5f);
    }

    private void ensure_background_controller()
    {
        if (this.obj_main_board_bk == null) return;

        BoardBackgroundController controller = this.obj_main_board_bk.GetComponent<BoardBackgroundController>();
        if (controller == null)
        {
            controller = this.obj_main_board_bk.AddComponent<BoardBackgroundController>();
        }

        controller.RefreshLayout();
    }

    private void apply_random_background()
    {
        if (this.obj_main_board_bk == null || this.backgroundSprites == null || this.backgroundSprites.Length == 0) return;

        SpriteRenderer renderer = this.obj_main_board_bk.GetComponent<SpriteRenderer>();
        if (renderer == null) return;

        Sprite background = this.backgroundSprites[Random.Range(0, this.backgroundSprites.Length)];
        if (background == null) return;

        renderer.sprite = background;

        BoardBackgroundController controller = this.obj_main_board_bk.GetComponent<BoardBackgroundController>();
        if (controller != null)
        {
            controller.RefreshLayout();
        }
    }

}
