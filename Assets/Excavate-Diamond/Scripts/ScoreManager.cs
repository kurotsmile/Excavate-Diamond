using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text txt_socre_you;
    public Text txt_socre_hight;

    public int tileRatio;
    public int comboRatio;

    private int HighScore=0;
    private int currentScore=0;

    public void load()
    {
        this.HighScore = PlayerPrefs.GetInt("HighScore",0);
        ResetCurrentScore();
    }

    public void ResetCurrentScore()
    {
        this.currentScore = 0;
        this.update_score_UI();
    }

    private void update_score_UI()
    {
        this.txt_socre_hight.text = this.HighScore.ToString();
        this.txt_socre_you.text = this.currentScore.ToString();
    }

    public void IncrementCurrentScore(int tileCount, int comboCount)
    {
        this.currentScore += (tileCount * tileRatio) * (comboCount * comboRatio);

        SoundManager.Instance.PlayScore(comboCount > 1);
        if(comboCount > 1)  GameObject.Find("Game").GetComponent<Game_Handle>().create_effect();

        this.update_score_UI();
    }

    public void SetHighScore()
    {
        if (this.currentScore > this.HighScore)
        {
            this.HighScore = currentScore;
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }

    public int get_currentScore()
    {
        return this.currentScore;
    }

    public int get_HighScore()
    {
        return this.HighScore;
    }
}
