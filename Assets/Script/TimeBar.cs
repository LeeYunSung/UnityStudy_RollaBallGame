using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField]
    private Image barImage;
    public Text timeText;
    public float leftTime;
    const float MAXTIME = 60;

    PlayerController playerController;

    public void Start()
    {
        leftTime = MAXTIME;
        timeText.text = "Time: " + leftTime + " sec";
        StartCoroutine(Timer());
        playerController = FindObjectOfType<PlayerController>();

    }
    IEnumerator Timer()
    {
        while (true)
        {
            barUpdate(MAXTIME, leftTime);
            if (leftTime < 0)
            {
                leftTime = 0;
                timeText.text = "Time: 0 sec";
                playerController.isStart = false;
                break;
            }
            else if (leftTime >= MAXTIME)
            {
                leftTime = MAXTIME;
            }
            timeText.text = "Time: " + (int)leftTime + " sec";
            yield return new WaitForSeconds(Time.deltaTime);
            leftTime -= Time.deltaTime;
        }
    }
    public void barUpdate(float maxTime, float leftTime)
    {
        barImage.fillAmount = leftTime / maxTime;
    }
}