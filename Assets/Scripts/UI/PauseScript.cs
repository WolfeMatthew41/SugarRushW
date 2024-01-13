using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseScript : MonoBehaviour
{

    private bool _isPaused = false;

    public GameObject PauseMenu;

    public UnityEvent onPauseEvent;

    public UnityEvent onUnPauseEvent;



    public void OnPause()
    {
        if (!_isPaused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _isPaused = true;
            AkSoundEngine.SetState("GameStates", "Pause");
            AkSoundEngine.SetState("PauseStates", "PauseOn");
            onPauseEvent.Invoke();

        }
        else 
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _isPaused = false;
            AkSoundEngine.SetState("GameStates", "Ingame");
            AkSoundEngine.SetState("PauseStates", "PauseOff");
            onUnPauseEvent.Invoke();
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
