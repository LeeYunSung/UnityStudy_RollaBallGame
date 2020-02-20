using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Image barImage;
    [SerializeField] private Text timeText;

    private float leftTime;
    const float MAXTIME = 10;

    public void Start(){
        leftTime = MAXTIME;
        timeText.text = "Time: " + leftTime + " sec";
        StartCoroutine(Timer());
    }
    IEnumerator Timer(){
        while (true){
            BarUpdate(MAXTIME, leftTime);
            if (leftTime < 0){
                leftTime = 0;
                timeText.text = "Time: 0 sec";
                Time.timeScale = 0;
                gameManager.SaveScore();
                break;
            }
            else if (leftTime >= MAXTIME){
                leftTime = MAXTIME;
            }
            timeText.text = "Time: " + (int)leftTime + " sec";
            yield return new WaitForSeconds(Time.deltaTime);
            leftTime -= Time.deltaTime;
        }
    }
    public void BarUpdate(float maxTime, float leftTime){
        barImage.fillAmount = leftTime / maxTime;
    }

    public void TimeUpdate(float time){
        leftTime -= time;
    }
}