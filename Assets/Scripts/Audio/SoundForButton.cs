using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundForButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        AkSoundEngine.PostEvent("Play_UI_Sound_ButtonClick", gameObject);
    }
}
