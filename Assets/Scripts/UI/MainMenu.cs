using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Scene currentScene;
    public Canvas controlsOverlay;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && controlsOverlay.enabled == true)
        {
            controlsOverlay.enabled = false;
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Controls()
    {
       
        controlsOverlay.enabled = true;
       
    }
}
