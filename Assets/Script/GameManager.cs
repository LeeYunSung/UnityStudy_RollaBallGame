using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject restartView;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private Text rankingScore;

    private int mScore;
    
    void Start(){
        restartView.SetActive(false);
        SetScoreText();
    }

    public void SetScoreText(){
        totalScoreText.text = "Score: " + mScore;
    }

    public void SetScore(int score){
        mScore += score;
        SetScoreText();
    }

    public void OnClickRestart(){
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void SaveScore()
    {
        restartView.SetActive(true);

        //first save
        if (!PlayerPrefs.HasKey("Score")){
            rankingScore.text = mScore.ToString();
            PlayerPrefs.SetInt("Score", mScore);
            PlayerPrefs.Save();
            return;
        }
        //save
        string scoreString = PlayerPrefs.GetString("Score") + '\n' + mScore.ToString();
        PlayerPrefs.SetString("Score", scoreString);
        PlayerPrefs.Save();

        //prepare show
        string[] data = PlayerPrefs.GetString("Score").Split('\n');
        int[] dataIn = new int[data.Length];
        for (int i = 0; i < data.Length; i++){
            dataIn[i] = System.Convert.ToInt32(data[i]);
        }
        //sort
        for (int i = 0; i < data.Length - 1; i++)
        {
            for (int j = i + 1; j < data.Length; j++)
            {
                if (dataIn[i] < dataIn[j])
                {
                    int temp = dataIn[i];
                    dataIn[i] = dataIn[j];
                    dataIn[j] = temp;
                }
            }     }
        //show
        for (int i = 0; i < data.Length; i++){
            if (i > 4){
                break;
            }
            rankingScore.text += dataIn[i] + "\n";
        }
    }
    public void OnClickQuit() { 
        Application.Quit();
    }
   
}

