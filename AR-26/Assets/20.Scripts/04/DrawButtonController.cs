using UnityEngine;
using TMPro;

public class DrawButtonController : MonoBehaviour
{
    public TextMeshProUGUI drawText;

    int toggle = 0;
    public void ChangeMode()
    {
        toggle = (toggle + 1) % 2;
        if(toggle==1)
        {
            drawText.text = "Stop";
        }
        else
        {
            drawText.text = "Draw";
        }
    }
}
