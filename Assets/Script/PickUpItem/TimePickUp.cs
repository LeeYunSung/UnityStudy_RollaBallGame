using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickUp : PickUp
{
    public float time;
    PickUpGenerator pickUpGenerator;
    TimeBar timeBar;

    private void Start(){
        pickUpGenerator = FindObjectOfType<PickUpGenerator>();
        timeBar = FindObjectOfType<TimeBar>();
        StartCoroutine(SelfDestroy());
    }
    IEnumerator SelfDestroy(){
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        pickUpGenerator.Clone();  
    }
    public override void Change(){
        timeBar.TimeUpdate(time);
    }
}