using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaToFull : MonoBehaviour
{
    public GameObject spatula;
    public GameObject FullSpatulaPrefab;
    Vector3 spatulaPosition;
    Vector3 ogPosition;

    private void Start()
    {
        //ogPosition = scoop.transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "mixture")
        {
            spatulaPosition = spatula.transform.position - new Vector3(0, 0, 2);
            Destroy(spatula);
            Instantiate(FullSpatulaPrefab, spatulaPosition, Quaternion.identity);
        }
    }
}
