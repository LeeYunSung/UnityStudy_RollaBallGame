using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField]
    private Image barImage;

    public void barUpdate(float maxTime, float leftTime)
    {
        barImage.fillAmount = leftTime / maxTime;
    }
}