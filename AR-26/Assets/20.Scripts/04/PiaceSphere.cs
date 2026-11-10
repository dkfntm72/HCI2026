using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PiaceSphere : MonoBehaviour
{
    public GameObject spherePrefab;
    public Camera arCamra;
    public Transform parentTransform;

    private void Update()
    {
        //int touchCount = Input.touchCount;
        //if (touchCount < 1) return;

        //Touch touch = Input.GetTouch(0);
        //Vector3 touchPositon = arCamra.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 0.5f));
        //if (touch.phase == TouchPhase.Began)
        //{
        //    GameObject go = Instantiate(spherePrefab, touchPositon, transform.rotation);
        //    go.transform.parent = parentTransform;
        //    go.transform.position = touchPositon;
        //}
        if (EventSystem.current.currentSelectedGameObject) return;

        var touchScreen = Touchscreen.current;
        if (touchScreen == null) return;

        if (!touchScreen.primaryTouch.press.wasPressedThisFrame) return;

        Vector2 screenPos = touchScreen.primaryTouch.position.ReadValue();
        Vector2 worldPos = arCamra.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 0.5f));

        GameObject go = Instantiate(spherePrefab, worldPos, Quaternion.identity);
        go.transform.parent = parentTransform;

        GameManager.Instance.ShowMessage("Sphere generated.");
    }

}
