using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceencontroller : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    // Method to load Win Scene
    public void LoadWinScene()
    {
        SceneManager.LoadScene("WinScene");
    }

    // Method to load Lose Scene
    public void LoadLoseScene()
    {
        SceneManager.LoadScene("LoseScene");
    }

    // Method to load Time Out Scene
    public void LoadTimeOutScene()
    {
        SceneManager.LoadScene("TimeOutScene");
    }
}
