//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GoodFruit : MonoBehaviour
{
    public int energyBonus = 10;

    PlayerEnergy playerEnergy;
    private bool hasEventBeenTriggered = false;
    public AK.Wwise.Event Play_GoodOrBadFruit;

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
        GoodFruitSwitch("GoodFruit");

        //we have to play event only once
        if (!hasEventBeenTriggered)
        {
            if (other.CompareTag("Player"))
            {
                PlayFruit();
                hasEventBeenTriggered = true;
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
}
