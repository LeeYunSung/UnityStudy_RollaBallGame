using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickUp : PickUp
{
    public float time;
    PickUpGenerator pickUpGenerator;
    PlayerController playerController;

    private void Start()
    {
        pickUpGenerator = FindObjectOfType<PickUpGenerator>();
        playerController = FindObjectOfType<PlayerController>();
        StartCoroutine(SelfDestroy());
    }
    IEnumerator SelfDestroy()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
            pickUpGenerator.Clone();
        }
    }
    public void Change()
    {
        playerController.timeBar.leftTime -= time;
    }
}