using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour 
{
    protected void Update(){
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
    public virtual void Change() { }
}