using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGenerator : MonoBehaviour
{
    const int SIZE = 10;
    public GameObject[] objects;
    public int colorNum;

    void Start()
    {
        for(int i = 0; i<SIZE; i++) Clone();
    }
    public void Clone(){
        colorNum = Random.Range(0, objects.Length);
        Vector2 position = Random.insideUnitCircle * 10;
        Vector3 pos = new Vector3(position.x, .5f, position.y);

        GameObject childPickUp = Instantiate(objects[colorNum], pos, Quaternion.identity) as GameObject;
        childPickUp.transform.parent = transform;
    }
}