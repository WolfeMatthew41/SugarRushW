using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeSettings : MonoBehaviour
{
    public string wwiseRTPCName = "MasterVolume"; 
    public Slider volumeSlider;
    public string wwiseRTPCName2 = "MusicVolume";
    public Slider MusicVolumeSlider;
    public string wwiseRTPCName3 = "SFXVolume";
    public Slider SFXVolumeSlider;

    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        MusicVolumeSlider.onValueChanged.AddListener(UpdateVolume);
        SFXVolumeSlider.onValueChanged.AddListener(UpdateVolume);
    }

    private void UpdateVolume(float value)
    {
        Debug.Log("Slider Value: " + value);

        float scaledValue = value;
        Debug.Log("Scaled RTPC Value: " + scaledValue);
        AkSoundEngine.SetRTPCValue(wwiseRTPCName, scaledValue);
    }
    private void UpdateVolumeMusic(float value1)
    {
        Debug.Log("Slider Value: " + value1);

        float scaledValue1 = value1;
        Debug.Log("Scaled RTPC Value: " + scaledValue1);
        AkSoundEngine.SetRTPCValue(wwiseRTPCName2, scaledValue1);
    }
    private void UpdateVolumeSFX(float value2)
    {
        Debug.Log("Slider Value: " + value2);

        float scaledValue2 = value2;
        Debug.Log("Scaled RTPC Value: " + scaledValue2);
        AkSoundEngine.SetRTPCValue(wwiseRTPCName3, scaledValue2);
    }
}