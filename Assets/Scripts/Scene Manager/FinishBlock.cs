using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBlock : MonoBehaviour
{
    // Lets each level set the next level to load. Default set to -1 for scene check
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] PathManager pathManager;
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
        if(inFinishLocation == true && pathManager.GetPathCount() <= 0)
        {
            SceneManager.LoadSceneAsync(sceneToLoad);
        }
    }
}