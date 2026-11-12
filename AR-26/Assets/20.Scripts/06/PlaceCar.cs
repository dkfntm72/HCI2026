using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlaceCar : MonoBehaviour
{

    public GameObject marker;

    ARRaycastManager arRayManager;
    void Start()
    {
        arRayManager = GetComponent<ARRaycastManager>();
        marker.SetActive(false);
    }

    void Update()
    {
        DetectGround();
    }
    void DetectGround()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if(arRayManager.Raycast(screenCenter,hits,TrackableType.Planes))
        {
            marker.SetActive(true);
            marker.transform.position = hits[0].pose.position;
        }
    }
}
