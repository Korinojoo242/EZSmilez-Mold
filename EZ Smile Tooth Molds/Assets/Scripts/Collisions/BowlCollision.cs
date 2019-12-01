using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlCollision : MonoBehaviour
{
    public GameObject bowl;
    public GameObject mixBowl;
    Vector3 bowlPosition;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grabbable")
        {
            bowlPosition = bowl.transform.position - new Vector3 (0f,.9f,0f);
            Destroy(bowl);
            Instantiate(mixBowl, bowlPosition, Quaternion.identity);
        }
    }
}
