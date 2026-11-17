using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DrawLines : MonoBehaviour
{
    public LineSettings lineSetting;
    public Camera arCam;

    ARPlaneManager arPlaneManager;
    bool Initialized = false;
    bool canDraw = false;
    bool isStarting = false;
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
        if (!Initialized) return;
        if (!canDraw) return;
    }
}
