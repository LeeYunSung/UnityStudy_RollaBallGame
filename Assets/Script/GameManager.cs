using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject restartView;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private Text rankingScore;

    private int mScore;

    void Start()
    {
        restartView.SetActive(false);
        SetScoreText();
    }

    public void SetScoreText()
    {
        totalScoreText.text = "Score: " + mScore;
    }

    public void SetScore(int score)
    {
        mScore += score;
        SetScoreText();
    }

    public void OnClickRestart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void SaveScore()
    {
        restartView.SetActive(true);

        PlayerPrefs.SetInt("Score", mScore);//save
        PlayerPrefs.Save();
        if (PlayerPrefs.HasKey("Score")) // do you have data?
        {
            rankingScore.text = PlayerPrefs.GetInt("Score").ToString();
        }
    }
}
