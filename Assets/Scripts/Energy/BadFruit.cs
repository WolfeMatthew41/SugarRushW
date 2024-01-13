using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFruit : MonoBehaviour
{
    public int energyDecrease = 10;

    PlayerEnergy playerEnergy;
    private bool fruitAlive = true;
    private bool hasEventBeenTriggered = false;
    public AK.Wwise.Event Play_GoodOrBadFruit;

    private void OnEnable()
    {
        FruitSpawner1.onDespawn += despawn;
    }

    private void OnDisable()
    {
        FruitSpawner1.onDespawn -= despawn;
    }

    private void despawn()
    {
        Destroy(gameObject);
    }


    void Awake()
    {
        playerEnergy = FindObjectOfType<PlayerEnergy>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (fruitAlive)
        {
            BadFruitSwitch("BadFruit");

            //we have to play event only once
            if (!hasEventBeenTriggered)
            {
                if (other.CompareTag("Player"))
                {
                    PlayFruit();
                    hasEventBeenTriggered = true;

                    if (playerEnergy.currentEnergy > 0)
                    {
                        Destroy(gameObject);
                        fruitAlive = false;
                        playerEnergy.currentEnergy -= energyDecrease;
                    }
                    Debug.Log("Player Entered");
                }
                else if (other.CompareTag("FruitClear"))
                {
                    Destroy(gameObject);
                }

            }
        }


        
    }
    private void OnTriggerExit(Collider other)
    {

        hasEventBeenTriggered = false;
    }


    public void BadFruitSwitch(string switchName)
    {
        AkSoundEngine.SetSwitch("GoodOrBadFruit", switchName, gameObject);
        Debug.Log("BadFruit");

    }
    void PlayFruit()
    {

        //Should check if there is fruit event
        if (Play_GoodOrBadFruit != null)
        {

            Play_GoodOrBadFruit.Post(gameObject);
        }
        else
        {

            Debug.LogWarning("No assigned Wwise event");
        }
    }
}
