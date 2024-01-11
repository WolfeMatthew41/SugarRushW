using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    public AK.Wwise.Event Play_Footstep;
    public void GroundMaterialSwitch(string switchName)
    {

        AkSoundEngine.SetSwitch("GroundMaterial", switchName, gameObject);
        PlayFootstep();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dirt"))
        {
            GroundMaterialSwitch("Dirt");
        }
        else if (other.CompareTag("Grass"))
        {
            GroundMaterialSwitch("Grass");
        }
    }
    void PlayFootstep()
    {
        if (Play_Footstep != null)
        {

            Play_Footstep.Post(gameObject);
        }
        else
        {

            Debug.LogWarning("No assigned Wwise event");
        }
    }
}
