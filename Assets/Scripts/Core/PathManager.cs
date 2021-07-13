using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    [SerializeField] GameObject blockExplosionVFX;

    Rigidbody rb;
    Portal nextLevel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextLevel = GetComponent<Portal>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Entering Block");
        }
        if(other.CompareTag("Player") && gameObject.tag == "Finish")
        {
            print("to load next level");
            nextLevel.LevelLoad();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(rb != null)
            {
                Instantiate(blockExplosionVFX, transform.position, transform.rotation);
                rb.useGravity = true;
                rb.isKinematic = false;
                Destroy(gameObject, 5f);
            }
        }
    }

}
