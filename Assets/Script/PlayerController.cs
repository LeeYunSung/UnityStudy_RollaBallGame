using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public Joystick joystick;
    public float speed;

    private int count;

    public Text countText;
    public Text winText;
    public Text timeText;

    private Rigidbody rb;

    public TimeBar timeBar;
    const float MAXTIME = 60;
    float leftTime;

    PickUpGenerator pickUpGenerator;
    public GameObject player;

    public bool isStart;

    [SerializeField]
    GameObject restartView;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 0.1f;
        leftTime = MAXTIME;
        winText.text = "";
        timeText.text = "Time: " + leftTime + " sec";
        SetCountText();
        pickUpGenerator = FindObjectOfType<PickUpGenerator>();
        restartView.SetActive(false);
        StartCoroutine(MovePlayer());
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        while (true)
        {
            timeBar.barUpdate(MAXTIME, leftTime);
            if (leftTime < 0)
            {
                leftTime = 0;
                timeText.text = "Time: 0 sec";
                isStart = false;
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
            count += other.gameObject.GetComponent<PickUp>().score;
        }
        if (other.GetComponent<TimePickUp>() != null)
        {
            leftTime -= other.gameObject.GetComponent<TimePickUp>().time;
        }
        other.gameObject.SetActive(false);
        SetCountText();
        pickUpGenerator.Clone();
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 15)
        {
            winText.text = "You Win!";
        }
    }

    public void OnClickRestart() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }


}