using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOffScript : MonoBehaviour
{

    public GameObject GameOverMenu;

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
    }
}
