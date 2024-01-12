using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    public AK.Wwise.Event Play_MainMenu;
    public AK.Wwise.Event Stop_MainMenu;
    void Start()
    {
        // Perform initialization tasks here

        // For example, you can print a message to the console
        Debug.Log("Script is initialized!");
        PlayMainMenu();
    }


    public void OnStartGame()
    {
        StopMainMenu();
        SceneManager.LoadScene(1);
       
    }

    public void OnSettings()
    { 
    }

    public void OnExit()
    {
        Application.Quit();
    }
    void PlayMainMenu()
    {

        //Should check if there is fruit event
        if (Play_MainMenu != null)
        {

            Play_MainMenu.Post(gameObject);
        }
        else
        {

            Debug.LogWarning("No assigned Wwise event");
        }
    }
    void StopMainMenu()
    {

        //Should check if there is fruit event
        if (Stop_MainMenu != null)
        {

            Stop_MainMenu.Post(gameObject);
        }
        else
        {

            Debug.LogWarning("No assigned Wwise event");
        }
    }
}
