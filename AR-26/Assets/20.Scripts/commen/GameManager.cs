using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject spherePrefab;
    public TextMeshProUGUI messageText;
    public bool isDrawing = false;
    Vector3 prevPosition = new Vector3(0, 0, 0);
    public Camera arCamera;

    public static GameManager Instance
    {
        get
        {
            if(m_instance==null)
            {
                m_instance = FindAnyObjectByType<GameManager>();
            }
            return m_instance;
        }
    }
    static GameManager m_instance;
    public void GameOver()
    {
        Application.Quit();
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
    }
    private void Update()
    {
        DrawSphrers();
    }

    void DrawSphrers()
    {
        if (!isDrawing) return;

        Vector3 currentPositon = arCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0.5f));

        float distance = Vector3.Distance(currentPositon, prevPosition);
        if (distance > 0.3f) return;

        GameObject go = Instantiate(spherePrefab, currentPositon, Quaternion.identity);
        go.transform.parent = transform;
        prevPosition = go.transform.position;
    }
}
