//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GoodFruit : MonoBehaviour
{
    public int energyBonus = 10;

    PlayerEnergy playerEnergy;

    void Awake()
    {
        playerEnergy = FindObjectOfType<PlayerEnergy>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(playerEnergy.currentEnergy < playerEnergy.maxEnergy)
        {
            Destroy(gameObject);
            playerEnergy.currentEnergy += energyBonus;
        }
        Debug.Log("Player Entered");
    }

    void OnColliderEnter(Collider other)
    {
       
    }
}
