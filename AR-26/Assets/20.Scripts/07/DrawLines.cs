using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DrawLines : MonoBehaviour
{
    public LineSettings lineSetting;
    public Camera arCam;

    Dictionary<int, ARLine> lines = new Dictionary<int, ARLine>();

    ARPlaneManager arPlaneManager;
    bool Initialized = false;
    bool canDraw = false;
    bool isStarting = false;
    int lineCount = -1;
    private void Awake()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlaneChanged;
    }

    void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if(!Initialized)
        {
            Initialized = true;
        }
    }
    public void AllowDraw(bool isAllow)
    {
        if (!Initialized) return;

        canDraw = isAllow;
        if (canDraw) isStarting = true;
    }
    private void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
        if (!canDraw) return;

        Vector3 drawPositon = arCam.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0.2f));

        if(isStarting)
        {
            isStarting = false;
            ARLine line = new ARLine(lineSetting);
            lineCount++;
            lines.Add(lineCount, line);
            line.AddNewLineRenderer(transform, drawPositon);
        }
        else
        {
            lines[lineCount].AddPoint(drawPositon);
        }
    }
}
