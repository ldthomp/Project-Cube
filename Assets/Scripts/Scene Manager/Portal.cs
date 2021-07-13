using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Lets each level set the next level to load. Default set to -1 for scene check
    [SerializeField] int sceneToLoad = -1;
    private void Start()
    {
        
    }

    
    public void LevelLoad()
    {
        if (sceneToLoad < 0)
        {
            Debug.LogError("scene to load not set.");
            return;
        }
        SceneManager.LoadSceneAsync(sceneToLoad); 
    }
}
