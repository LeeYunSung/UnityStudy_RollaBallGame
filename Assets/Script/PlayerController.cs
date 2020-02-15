using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public float speed;
    public int score;

    public Text totalScoreText;

    private Rigidbody rb;

    public TimeBar timeBar;

    PickUpGenerator pickUpGenerator;
    public GameObject player;

    public bool isStart;

    [SerializeField]
    GameObject restartView;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 0.1f;
        SetCountText();
        pickUpGenerator = FindObjectOfType<PickUpGenerator>();
        restartView.SetActive(false);
        StartCoroutine(MovePlayer());
    }

    IEnumerator MovePlayer()
    {
        isStart = true;
        while (isStart)
        {
            float moveHorizontal = joystick.moveHorizontal;
            float moveVertical = joystick.moveVertical;
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = movement * speed;
            yield return null;
        }
        Time.timeScale = 0;
        restartView.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PickUp>() != null)
        {
            //닿은 객체의 score, time 변수에 따라 값 변경하라고 일러주기. 
            Destroy(other.gameObject);
            pickUpGenerator.Clone();
            SetCountText();
        }
    }

    void SetCountText()
    {
        totalScoreText.text = "Score: " + score.ToString();
    }

    public void OnClickRestart() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}