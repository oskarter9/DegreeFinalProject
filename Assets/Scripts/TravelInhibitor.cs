using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelInhibitor : MonoBehaviour {

    public Material TimeTravelPortal;
    public Material NonWorkingTravelPortal;

    void OnTriggerEnter(Collider c)
    {
        if (c.GetComponent<CharacterController>())
        {
            var timeTravelDevice = ReferencesManager.instance.PlayerObjectsContainer.GetComponentInChildren<TwinCameraController>();
            timeTravelDevice.enabled = false;
            timeTravelDevice.Portal.GetComponent<Renderer>().material = NonWorkingTravelPortal;
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.GetComponent<CharacterController>())
        {
            var timeTravelDevice = ReferencesManager.instance.PlayerObjectsContainer.GetComponentInChildren<TwinCameraController>();
            timeTravelDevice.enabled = true;
            timeTravelDevice.Portal.GetComponent<Renderer>().material = TimeTravelPortal;
        }
    }
}
