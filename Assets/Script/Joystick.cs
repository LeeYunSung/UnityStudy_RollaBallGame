using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static Image joystick;

    private Vector2 defaultPosition;
    public float moveHorizontal;
    public float moveVertical;

    [SerializeField]
    private float Radius;
    private Vector3 centerPt;

    void Start() {
        joystick = GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData){
        defaultPosition = joystick.transform.position;
        centerPt = new Vector3(defaultPosition.x, defaultPosition.y, 0.0f);
    }
    public void OnDrag(PointerEventData eventData){ 
        Vector3 movement = new Vector3(eventData.position.x, eventData.position.y, 0);
        Vector3 offset = movement - centerPt;
        transform.position = centerPt + Vector3.ClampMagnitude(offset, Radius);

        moveHorizontal = transform.position.x - defaultPosition.x;
        moveVertical = transform.position.y - defaultPosition.y;
    }
    public void OnEndDrag(PointerEventData eventData){
        transform.position = defaultPosition;
        moveHorizontal = moveVertical = 0;
    }
}