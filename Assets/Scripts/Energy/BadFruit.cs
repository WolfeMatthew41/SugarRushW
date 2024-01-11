using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFruit : MonoBehaviour
{
    public int energyDecrease = 10;

    PlayerEnergy playerEnergy;

    void Awake()
    {
        playerEnergy = FindObjectOfType<PlayerEnergy>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(playerEnergy.currentEnergy > 0)
        {
            Destroy(gameObject);
            playerEnergy.currentEnergy -= energyDecrease;
        }
        Debug.Log("Player Entered");
    }
}
