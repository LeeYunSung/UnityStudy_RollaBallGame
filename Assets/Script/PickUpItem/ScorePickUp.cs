using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickUp : PickUp
{
    public int score;
    [SerializeField] private GameManager gameManager;

    private void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }
    public override void Change(){
        gameManager.SetScore(score);
    }
}
