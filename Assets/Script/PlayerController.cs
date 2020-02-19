using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : GameManager
{
    public Joystick joystick;
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private PickUpGenerator pickUpGenerator;

    void Start(){
        speed = 0.1f;
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MovePlayer());
    }

    IEnumerator MovePlayer(){
        while (true){
            float moveHorizontal = joystick.moveHorizontal;
            float moveVertical = joystick.moveVertical;
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.velocity = movement * speed;
            yield return null;
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.GetComponent<PickUp>() != null){
            PickUp pickUp = other.GetComponent<PickUp>();
            pickUp.Change();

            Destroy(other.gameObject);
            pickUpGenerator.Clone();
        }
    }
}