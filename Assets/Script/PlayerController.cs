using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private int count;

    public Text countText;
    public Text winText;
    public Text timeText;

    private Rigidbody rb;

    public TimeBar timeBar;
    float waitTime = 20;
    float time = 0;
    float weight = 0;
    
    PickUpGenerator pickUpGenerator;
    public GameObject player;

    public bool isStart;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10;
        time = waitTime;
        winText.text = "";
        timeText.text = "Time: "+ waitTime +" sec";
        SetCountText();

        pickUpGenerator = FindObjectOfType<PickUpGenerator>();
        //manaBar = GetComponent<ManaBar>(); //요롷게 하면 자기한테 있는 ManaBar를 찾기 때문에 ManaBar를 못찾는 것!
                                            //manaBar = manaBar.GetComponent<ManaBar>(); 이렇게 해도 계속 같은거 들고 무한 루프 도는 것 밖에 안됨!
        //https://dodnet.tistory.com/2927

        StartCoroutine(MovePlayer());
        StartCoroutine(Timer());
    }

    //Timer Coroutine 동작
    IEnumerator Timer()
    {
        while (time >= 0)
        {
            yield return new WaitForSeconds(0.01f);
            time -= 0.01f;
            timeText.text = "Time: " + (int)time + " sec";
            timeBar.barUpdate(waitTime, weight);
            weight = 0;
        }
        Time.timeScale = 0;
    }

    //플레이어 움직임
    IEnumerator MovePlayer()
    {
        isStart = true;
        while (isStart)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);
            yield return null;
        }
    }

    //블럭이랑 닿으면 사라짐
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PickUp>() != null)
        {
            other.gameObject.SetActive(false);
            count += other.gameObject.GetComponent<PickUp>().score;
            weight = other.gameObject.GetComponent<PickUp>().time;
            waitTime -= weight;
            SetCountText();
            pickUpGenerator.Clone();
        }
    }
    //점수 & You Win 출력
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}