using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEnergy : MonoBehaviour
{
    public int maxEnergy = 100;
    public int currentEnergy;

    public int energyDeplete = 1;

    public EnergySystem energyBar;

    public GameObject GameOverMenu;

    public UnityEvent onPauseEvent;

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
        InvokeRepeating("DecreaseEnergy", 1.0f, 1.0f);
    }

    void Update()
    {
        //DecreaseEnergy(1);
    }

    void DecreaseEnergy()
    {
        //int energy = 1;
        if (currentEnergy > 0)
        {
            currentEnergy -= energyDeplete;
            energyBar.SetEnergy(currentEnergy);
        }
        else
        {
            OnRushOut();
        }
    }

    public void OnRushOut()
    {
        GameOverMenu.SetActive(true);
        AkSoundEngine.SetState("PlayerStates", "Sleep");
        Time.timeScale = 0f;
        onPauseEvent.Invoke();
    }
}
