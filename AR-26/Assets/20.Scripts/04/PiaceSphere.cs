using UnityEngine;

public class PiaceSphere : MonoBehaviour
{
    public GameObject spherePrefab;
    public Camera arCamra;
    public Transform parentTransform;

    private void Update()
    {
        int touchCount = Input.touchCount;
        if (touchCount < 1) return;

        Touch touch = Input.GetTouch(0);
        Vector3 touchPositon = arCamra.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0.5f));
        if (touch.phase == TouchPhase.Began)
        {
            GameObject go = Instantiate(spherePrefab, touchPositon, transform.rotation);
            go.transform.parent = transform;
            go.transform.position = touchPositon;
        }
    }

}
