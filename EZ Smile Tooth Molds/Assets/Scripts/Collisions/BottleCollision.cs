using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleCollision : MonoBehaviour 
{
    Vector3 originalPos;
    public GameObject Bottle;

    void Start()
    {
        originalPos = gameObject.transform.position;
        //alternatively, just: originalPos = gameObject.transform.position;

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bowl")
        {
            Destroy(Bottle);
        }

        else
        {
            gameObject.transform.position = originalPos;
        }
    }
}
