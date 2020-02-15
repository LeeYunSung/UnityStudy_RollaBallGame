using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickUp : PickUp
{
    public int score;
    PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }
    public void Change()
    {
        playerController.score += score;
    }
}
