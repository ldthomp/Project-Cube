using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;

    Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if (pauseMenu.enabled) { pauseMenu.enabled = false; }
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentScene.name);
        }
     if(Input.GetKeyDown(KeyCode.Escape))
        {
            //TODO freeze game and controls
            if(!pauseMenu.enabled)
            {
                pauseMenu.enabled = true;
            }
            else
            {
                pauseMenu.enabled = false;
            }
        }
    }
    public void ReloadButton()
    {
        SceneManager.LoadScene(currentScene.name);
    }
    public void ExitButton()
    {
        //TODO reload to menu scene
    }
    public void ControlsOverlayUI()
    {
        //TODO add in UI overlay for showing the controls
    }
}
