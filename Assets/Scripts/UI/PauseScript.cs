using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{

    private bool _isPaused = false;

    public GameObject PauseMenu;



    public void OnPause()
    {
        if (!_isPaused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _isPaused = true;
        }
        else 
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _isPaused = false;
        }

    }

    public void OnSettings()
    { 
    }

    public void OnQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
