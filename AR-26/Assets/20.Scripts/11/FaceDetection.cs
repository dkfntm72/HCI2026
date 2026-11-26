using System.Collections.Generic;
using System.Diagnostics.Metrics;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceDetection : MonoBehaviour
{
    public GameObject positonCube;
    ARFaceManager afm;
    GameObject go = null;
    ARFace face = null;
    int index = -1;
    private void Awake()
    {
        afm = GetComponent<ARFaceManager>();
        go = Instantiate(positonCube, transform.position, transform.rotation);
        go.SetActive(false);

        afm.trackablesChanged.AddListener(args => 
        {
            foreach (var f in args.added) face = f;
            foreach (var kf in args.removed)
                if (kf.Value == face) face = null;
        });
    }
    public void OnClick()
    {
        if (face == null) return;
        if (face.vertices.Length < 0) return;
        
        go.SetActive(true);
        go.transform.position = face.transform.TransformPoint(face.vertices[index]);
        index++;
        if (index >= face.vertices.Length) index = 0;
    }
}
