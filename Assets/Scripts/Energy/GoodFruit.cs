//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GoodFruit : MonoBehaviour
{
    public int energyBonus = 10;

    PlayerEnergy playerEnergy;
    private bool hasEventBeenTriggered = false;
    private bool fruitAlive = true;
    public AK.Wwise.Event Play_GoodOrBadFruit;
    public AK.Wwise.Event Play_FruitGlow;
    public AK.Wwise.Event Stop_FruitGlow;

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
        if (fruitAlive)
        {
            PlayFruitGlow();
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (fruitAlive)
        {
            GoodFruitSwitch("GoodFruit");

            //we have to play event only once
            if (!hasEventBeenTriggered)
            {
                if (other.CompareTag("Player"))
                {
                    PlayFruit();
                    hasEventBeenTriggered = true;

                    if (playerEnergy.currentEnergy < playerEnergy.maxEnergy)
                    {
                        StopFruitGlow();
                        fruitAlive = false;
                        if (!fruitAlive)
                        {
                            StopFruitGlow();
                        }
                        Destroy(gameObject);

                        playerEnergy.currentEnergy += energyBonus;
                    }
                    Debug.Log("Player Entered");
                }
                else if(other.CompareTag("FruitClear"))
                {
                    StopFruitGlow();
                    fruitAlive = false;
                    if (!fruitAlive)
                    {
                        StopFruitGlow();
                    }
                    Destroy(gameObject);
                }

            }
        }


        
      
       
        
    }


    private void OnTriggerExit(Collider other)
    {
      
        hasEventBeenTriggered = false;
    }

    void OnColliderEnter(Collider other)
    {
       
    }
    public void GoodFruitSwitch(string switchName)
    {
        AkSoundEngine.SetSwitch("GoodOrBadFruit", switchName, gameObject);
        Debug.Log("GoodFruit");

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
    void PlayFruitGlow()
    {

        //Should check if there is fruit event
        if (Play_FruitGlow != null)
        {

            Play_FruitGlow.Post(gameObject);
        }
        else
        {

            Debug.LogWarning("No assigned Wwise event");
        }
    }
    void StopFruitGlow()
    {

        //Should check if there is fruit event
        if (Stop_FruitGlow != null)
        {

            Stop_FruitGlow.Post(gameObject);
        }
        else
        {

            Debug.LogWarning("No assigned Wwise event");
        }
    }
}
