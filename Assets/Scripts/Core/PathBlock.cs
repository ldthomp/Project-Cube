using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathBlock : MonoBehaviour
{
    [SerializeField] GameObject blockExplosionVFX;
    [SerializeField] PathManager path;
    [SerializeField] float timesToStepOnBlock = 1;

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
            timesToStepOnBlock--; //take 1 step away each time you step on block
            ChangeBlockColour();
            StartCoroutine(BlockBob());

        }
    }

    private void ChangeBlockColour()
    {
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<Renderer>().material.color = newColor;
    }

    IEnumerator BlockBob()
    {
        animator.SetBool("PlayerOnBlock", true);
        yield return new WaitForSeconds(0.15f); //time for animation to finish
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("PlayerOnBlock", false);
            if (rb != null && timesToStepOnBlock <= 0)
            {
                animator.SetTrigger("BlockToDrop");
                animator.enabled = false;
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
