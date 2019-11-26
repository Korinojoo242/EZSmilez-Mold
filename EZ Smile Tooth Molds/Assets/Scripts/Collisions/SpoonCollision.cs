using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonCollision : MonoBehaviour
{
    public GameObject scoop;
    public GameObject myPrefab;
   
        void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "alginate")
        {
            Destroy(scoop);
            Instantiate(myPrefab, new Vector3(0.9f, -3.5f, 1.48f), Quaternion.identity);
        }
    }
}
