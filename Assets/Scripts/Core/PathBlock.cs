﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathBlock : MonoBehaviour
{
    [SerializeField] GameObject blockExplosionVFX;
    [SerializeField] PathManager path;
    public NavMeshSurface navMeshSurface;

    Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        path = GetComponentInParent<PathManager>();

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
            if (rb != null)
            {
                gameObject.isStatic = false;
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
