using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public void OnRetry()
    {

        
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void OnQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
