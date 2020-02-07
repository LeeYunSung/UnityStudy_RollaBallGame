using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    [SerializeField]
    private Image barImage;

    public void barUpdate(float waitTime, float weight)
    {
        if(weight > 0)
        {
            barImage.fillAmount -= 0.01f * weight/ waitTime;
        }
        else if(weight < 0)
        {
            barImage.fillAmount -= 0.01f * weight / waitTime;
        }
        else barImage.fillAmount -= 0.01f / waitTime;
    }
}