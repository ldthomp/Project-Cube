using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBlock : MonoBehaviour
{
    // Lets each level set the next level to load. Default set to -1 for scene check
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] GameObject gate;
    [SerializeField] PathManager pathManager;
    [SerializeField] Canvas winScreen;

    public bool inFinishLocation = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inFinishLocation = true;
        }
    }
    private void Update()
    {
        var currentScene = SceneManager.GetActiveScene();
        if (pathManager == null) return;
        if(pathManager.GetPathCount() <= 0)
        {
            gate.SetActive(false);
        }
        
        if(inFinishLocation == true && pathManager.GetPathCount() <= 0)
        {

            SceneManager.LoadSceneAsync(sceneToLoad);
          
        }
    }
}