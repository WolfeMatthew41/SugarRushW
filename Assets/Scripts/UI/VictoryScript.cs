using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class VictoryScript : MonoBehaviour
{

    public GameObject VictoryMenu;

    public UnityEvent onPauseEvent;

    //*
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            OnVictory();
        }
    }//*/

    /*
    void OnCollisionEnter(Collision other)
    {
        
        if (other.collider.CompareTag("Player"))
        {
            OnVictory();
        }
    }*/

        public void OnVictory()
    {
        VictoryMenu.SetActive(true);
        AkSoundEngine.SetState("PlayerStates", "Victory");
        Time.timeScale = 0f;
        onPauseEvent.Invoke();
    }

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
