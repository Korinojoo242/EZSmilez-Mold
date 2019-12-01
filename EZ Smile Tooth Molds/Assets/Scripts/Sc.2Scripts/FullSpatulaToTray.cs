using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatulaToFull : MonoBehaviour
{
    public GameObject FullSpatula;
    public GameObject FullTray1Prefab;
    public GameObject FullTray1Prefab;
    Vector3 spatulaPosition;
    Vector3 ogPosition;
    Vector3 Tray1Position;
    Vector3 Tray1Position;

    private void Start()
    {
        //ogPosition = scoop.transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "tary1")
        {
            spatulaPosition = spatula.transform.position - new Vector3(0, 0, 2);
            Destroy(spatula);
            Instantiate(FullSpatulaPrefab, spatulaPosition, Quaternion.identity);
        }
    }
}