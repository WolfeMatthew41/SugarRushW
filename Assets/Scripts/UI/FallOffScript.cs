using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallOffScript : MonoBehaviour
{

    public GameObject GameOverMenu;

    public UnityEvent onPauseEvent;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            OnRushOut();
        }
    }

        public void OnRushOut()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        onPauseEvent.Invoke();
    }
}
