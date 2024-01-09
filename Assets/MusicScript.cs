using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;


public class MusicScript : MonoBehaviour
{
    // Set the name of your Wwise RTPC
    private const string rtpcName = "EnergyLevelRTPC";

    // Set the name of your Wwise event
    public AK.Wwise.Event playIngameEvent;

    // Slider UI for setting RTPC value during gameplay
    public Slider rtpcSlider;

    // Example: Name of the state groups
    private const string gameStateGroupName = "GameStates";
    private const string playerStateGroupName = "PlayerStates";

    // Example: Name of the states you want to set
    private const string gameState = "Ingame";
    private const string playerStateAwake = "Awake";
    private const string playerStateOutOfEnergy = "OutOfEnergy";
    private const string playerStateSleep = "Sleep";

    void Start()
    {
        // Example: Add an OnValueChanged callback during runtime
        rtpcSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Example: Play the Wwise event at the start with an initial RTPC value
        PlayIngame();

        // Example: Set the state of the state groups
        SetGameState(gameState);
        SetPlayerState(playerStateAwake);
    }

    void Update()
    {
        // Example: Pressing the space key plays the Wwise event
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Example: Play the Wwise event with the current RTPC value from the slider
            PlayIngame();
        }
    }

    // Example: Callback for slider value changes
    void OnSliderValueChanged(float value)
    {
        // Example: Ensure the RTPC value is within the valid range
        float clampedValue = Mathf.Clamp(value, 0f, 100f);

        // Example: Set the RTPC value dynamically
        AkSoundEngine.SetRTPCValue(rtpcName, clampedValue, gameObject);

        // Example: Debug the RTPC value during runtime
        Debug.Log($"RTPC {rtpcName} set to value: {clampedValue}");

        // Example: Check if the slider value is 0 and change player state to "OutOfEnergy"
        if (clampedValue == 0f)
        {
            OnOutOfEnergy();
        }
        // Example: Check if the slider value is greater than 0 and change player state to "Awake"
        else
        {
            OnAwake();
        }
    }

    // Example: Function to play the Wwise event with the current RTPC value from the slider
    void PlayIngame()
    {
        // Example: Get the RTPC value from the slider
        float rtpcValue = rtpcSlider.value;

        // Example: Ensure the RTPC value is within the valid range
        float clampedValue = Mathf.Clamp(rtpcValue, 0f, 100f);

        // Example: Set the RTPC value dynamically
        AkSoundEngine.SetRTPCValue(rtpcName, clampedValue, gameObject);

        // Example: Play the Wwise event
        if (playIngameEvent != null)
        {
            // Example: Ensure to call Post() with the gameObject parameter
            playIngameEvent.Post(gameObject);
        }
        else
        {
            // Example: Log a warning if the Wwise event is not set
            Debug.LogWarning("Wwise event is not assigned!");
        }
    }

    // Example: Function to set the state of the game state group
    void SetGameState(string state)
    {
        // Example: Set the state of the game state group to the target state
        AkSoundEngine.SetState(gameStateGroupName, state);

        // Example: Debug the state change during runtime
        Debug.Log($"State {state} set for group {gameStateGroupName}");
    }

    // Example: Function to set the state of the player state group
    void SetPlayerState(string state)
    {
        // Example: Set the state of the player state group to the target state
        AkSoundEngine.SetState(playerStateGroupName, state);

        // Example: Debug the state change during runtime
        Debug.Log($"State {state} set for group {playerStateGroupName}");
    }

    // Example: Function to handle when the player is out of energy
    void OnOutOfEnergy()
    {
        // Example: Set the player state to "OutOfEnergy"
        SetPlayerState(playerStateOutOfEnergy);
    }

    // Example: Function to handle when the player is awake
    void OnAwake()
    {
        // Example: Set the player state back to "Awake"
        SetPlayerState(playerStateAwake);
    }

    // Example: Function to handle when the player is sleeping
    void OnSleep()
    {
        // Example: Set the player state to "Sleep"
        SetPlayerState(playerStateSleep);
    }
}
