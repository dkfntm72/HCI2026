using UnityEngine;

public class Gamemanager2 : MonoBehaviour
{

    public static Gamemanager2 Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindAnyObjectByType<Gamemanager2>();
            }
            return m_instance;
        }
    }
    static Gamemanager2 m_instance;
    public void GameOver()
    {
        Application.Quit();
    }
}
