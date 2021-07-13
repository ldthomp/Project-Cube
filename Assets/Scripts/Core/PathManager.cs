using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] GameObject blockExplosionVFX;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Entering Block");
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
            }
        }
    }

}
