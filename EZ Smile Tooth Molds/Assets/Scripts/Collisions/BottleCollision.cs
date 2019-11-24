using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCollision : MonoBehaviour 
{
    public GameObject bottle;
    void OnCollisionEnter(Collision collision) 
    { 
        if (collision.gameObject.name == "Bowl") 
        { 
            Destroy(bottle); 
        } 
    } 
}
