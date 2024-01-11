using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{


    public void OnStartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OnSettings()
    { 
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
