using UnityEngine;
using TMPro;

public class DrawButtonContrallor : MonoBehaviour
{
    public TextMeshProUGUI drawText;

    int i = 0;
    public void ChangeDrawMode()
    {
        i = (i + 1) % 2;
        if (i == 1)
        {
            drawText.text = "Stop";
            GameManager.Instance.isDrawing = true;
            GameManager.Instance.ShowMessage("Start Drawin");
        }
        else
        {
            drawText.text = "Draw";
            GameManager.Instance.isDrawing = false;
            GameManager.Instance.ShowMessage("Stop Drawin");
        }
    }
}
