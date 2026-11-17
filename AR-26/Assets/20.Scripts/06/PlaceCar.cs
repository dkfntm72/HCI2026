using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlaceCar : MonoBehaviour
{

    public GameObject marker;
    public GameObject myCar;

    ARRaycastManager arRayManager;
    List<GameObject> carList = new List<GameObject>();
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
        else
        {
            marker.SetActive(false);
        }
    }

    public void PlaceMyCar()
    {
        if (!marker.activeSelf) return;
        GameObject go = Instantiate(myCar, marker.transform.position, marker.transform.rotation);
        carList.Add(go);
    }
    public void RemoveLastCar()
    {
        int count = carList.Count;
        if (count == 0) return;
        carList.RemoveAt(count - 1);

        GameObject go = carList[count - 1];
        Destroy(go);
        carList.RemoveAt(count - 1);
    }
}
