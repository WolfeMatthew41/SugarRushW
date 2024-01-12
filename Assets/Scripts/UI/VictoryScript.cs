using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{

    public GameObject VictoryMenu;

    //*
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            OnVictory();
            AkSoundEngine.SetState("PlayerStates", "Victory");
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
        Time.timeScale = 0f;
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
