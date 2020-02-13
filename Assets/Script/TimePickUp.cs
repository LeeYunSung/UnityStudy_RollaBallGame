using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickUp : MonoBehaviour
{
    public int score;
    public float time;
    public Material mMaterial;

    protected void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}