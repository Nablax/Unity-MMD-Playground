using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void play()
    {
        Debug.Log("Playing game...");
        SceneManager.LoadScene(1);
    }

    public void quit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
