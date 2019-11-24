using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRControl : MonoBehaviour
{
    public static UnityAction<bool> onHasController = null;
    private bool hasController = false;
    private bool inputActive = true;

    public GameObject player;
    public GameObject objectGrabbed;
    public GameObject controller;

    float distanceGrab;

    // Start is called before the first frame update
    private void Awake()
    {
        OVRManager.HMDMounted += playerFound;
        OVRManager.HMDUnmounted += playerLost;
    }

    private void OnDestroy()
    {
        OVRManager.HMDMounted -= playerFound;
        OVRManager.HMDUnmounted -= playerLost;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!inputActive)
        {
            return;
        }

        hasController = CheckController(hasController);

        bool triggerDown = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger);
        bool triggerUp = OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger);
        bool touchPad = OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad);

        if (triggerDown && objectGrabbed == null)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "Grabbable") //ensure that the game object is tagged with this!!!
                    {
                        objectGrabbed = hit.collider.gameObject;
                        distanceGrab = hit.distance;
                    }
                }
            }
        }

        if (objectGrabbed != null) // grabbing objects at a distance
        {
            objectGrabbed.transform.position = controller.transform.position + controller.transform.forward * distanceGrab;
            objectGrabbed.transform.rotation = controller.transform.rotation;
        }

        if (triggerUp)
        {
            objectGrabbed = null;
        }

        if (touchPad)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "Floor")
                {
                    player.transform.position = hit.point + hit.normal * 4.0f;
                }
            }
        }
    }
        
            private bool CheckController(bool currentValue)
            {
                bool controllerCheck = OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) || OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote);

                if (currentValue == controllerCheck)
                {
                    return currentValue;
                }

                if (onHasController != null)
                {
                    onHasController(controllerCheck);
                }
                return controllerCheck;
            }
            private void playerFound()
            {
                inputActive = true;
            }
            private void playerLost()
            {
                inputActive = false;
            }
}
