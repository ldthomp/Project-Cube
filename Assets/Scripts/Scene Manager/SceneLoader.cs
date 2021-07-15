﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    Scene currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
