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
}
