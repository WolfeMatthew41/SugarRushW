using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem;


public class MusicScript : MonoBehaviour
{

    private const string rtpcName = "EnergyLevelRTPC";


    public AK.Wwise.Event playIngameEvent;
    public AK.Wwise.Event playAmbienceEvent;

    
    public Slider rtpcSlider;

    
    private const string gameStateGroupName = "GameStates";
    private const string playerStateGroupName = "PlayerStates";
    private const string pauseStateGroupName = "PauseStates";

    
    private const string gameState = "Ingame";
    private const string playerStateAwake = "Awake";
    private const string playerStateOutOfEnergy = "OutOfEnergy";
    private const string playerStateSleep = "Sleep";
    private const string pauseStateOff = "PauseOff";



    void Start()
    {


        AkSoundEngine.StopAll();

        
        SetPauseState(pauseStateOff);

        PlayIngame();
        rtpcSlider.onValueChanged.AddListener(OnSliderValueChanged);
        PlayAmbience();


        SetGameState(gameState);
        SetPlayerState(playerStateAwake);
        
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
          /*  PlayIngame();*/
        }
    }

    
    void OnSliderValueChanged(float value)
    {
        
       float clampedValue = Mathf.Clamp(value, 0f, 100f);
        AkInitializationSettings initSettings = new AkInitializationSettings();

        // Optionally configure initSettings based on your needs

        // Initialize the Wwise Sound Engine
        if (!AkSoundEngine.IsInitialized())
        {
            AkSoundEngine.Init(initSettings);
            AkSoundEngine.SetRTPCValue(rtpcName, clampedValue, gameObject);
        }
        else
        {
            AkSoundEngine.SetRTPCValue(rtpcName, clampedValue, gameObject);
        }
        

        Debug.Log($"RTPC {rtpcName} set to value: {clampedValue}");

        // If the slider value is 0, change player state to "OutOfEnergy"
        if (clampedValue == 0f)
        {
            OnOutOfEnergy();
        }
        // If the slider value is greater than 0, change player state to "Awake"
        else
        {
            OnAwake();
        }
    }

    // Play Ingame music event with the current RTPC value from the slider
    void PlayIngame()
    {

        AkInitializationSettings initSettings = new AkInitializationSettings();

        // Optionally configure initSettings based on your needs

        // Initialize the Wwise Sound Engine
        if (!AkSoundEngine.IsInitialized())
        {
            AkSoundEngine.Init(initSettings);

        }

        // Get the RTPC value from the slider
        float rtpcValue = rtpcSlider.value;

        // Check range
        float clampedValue = Mathf.Clamp(rtpcValue, 0f, 100f);

        // Set RTPC value 
        AkSoundEngine.SetRTPCValue(rtpcName, clampedValue, gameObject);

        
        if (playIngameEvent != null)
        {
            
            playIngameEvent.Post(gameObject);
        }
        else
        {
            
            Debug.LogWarning("No assigned Wwise event");
        }
    }

    // setting game state 
    void SetGameState(string state)
    {
        
        AkSoundEngine.SetState(gameStateGroupName, state);

        
        Debug.Log($"State {state} set for {gameStateGroupName}");
    }

    // setting player state
    void SetPlayerState(string state)
    {
        
        AkSoundEngine.SetState(playerStateGroupName, state);

        
        Debug.Log($"State {state} set for {playerStateGroupName}");
    }
    void SetPauseState(string state)
    {

        AkSoundEngine.SetState(pauseStateGroupName, state);


        Debug.Log($"State {state} set for {pauseStateGroupName}");
    }

    // set player state to OutOfEnergy
    void OnOutOfEnergy()
    {
        
        SetPlayerState(playerStateOutOfEnergy);
    }

    // set player state to Awake
    void OnAwake()
    {
        
        SetPlayerState(playerStateAwake);
    }

    // set player state to sleep
    void OnSleep()
    {
        
        SetPlayerState(playerStateSleep);
    }


    void PlayAmbience()
    {
        

        if (playAmbienceEvent != null)
        {

            playAmbienceEvent.Post(gameObject);
        }
        else
        {

            Debug.LogWarning("No assigned Wwise event");
        }
    }
    private void OnDestroy()
    {
        AkInitializationSettings initSettings = new AkInitializationSettings();

        // Optionally configure initSettings based on your needs

        // Initialize the Wwise Sound Engine
        

        if (AkSoundEngine.IsInitialized())
        {
            // Stop all Wwise events globally
           
            Debug.Log("DESTROY DESTROY DESTROY ");
        }
        else
        {
            Debug.LogError("Wwise Sound Engine is not initialized.");
            AkSoundEngine.Init(initSettings);

        }
    }
}
