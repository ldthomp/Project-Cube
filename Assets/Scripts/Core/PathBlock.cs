using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathBlock : MonoBehaviour
{
    [SerializeField] GameObject blockExplosionVFX;
    [SerializeField] PathManager path;
    [SerializeField] float bobSpeed;

    Rigidbody rb;
    Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        path = GetComponentInParent<PathManager>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Entering Block");
            ChangeBlockColour();
            StartCoroutine(BlockBob());
            //TODO
            //object bobs up and down for a while after stepping on it
            //block changes colour while stepping on it to a random colour in a range
            //change colour back after leaving it
        }
    }

    private void ChangeBlockColour()
    {
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<Renderer>().material.color = newColor;
    }

    IEnumerator BlockBob()
    {
        animator.SetTrigger("PlayerOnBlock");
        yield return new WaitForSeconds(0.15f); //time for animation to finish
        animator.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (rb != null)
            {
                //gameObject.isStatic = false;
                Instantiate(blockExplosionVFX, transform.position, transform.rotation);
                rb.useGravity = true;
                rb.isKinematic = false;
                path.RemoveBlockFromList();
                Destroy(gameObject, 5f);
                transform.parent.GetComponent<NavMeshObstacle>().enabled = true;
            }
        }
    }
}
