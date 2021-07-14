using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBlock : MonoBehaviour
{
    // Lets each level set the next level to load. Default set to -1 for scene check
    [SerializeField] int sceneToLoad = -1;
    bool inFinishLocation = false;
    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag != "Player") return;
        //if (GetComponent<PathManager>().GetPathCount() >= 1) return;
        if (other.CompareTag("Player"))
        {
            inFinishLocation = true;
            SceneManager.LoadSceneAsync(sceneToLoad);
        }
    }
    private void Update()
    {
        if(inFinishLocation == true && FindObjectOfType<PathManager>().GetPathCount() <= 0)
        {
            SceneManager.LoadSceneAsync(sceneToLoad);
        }
    }
}