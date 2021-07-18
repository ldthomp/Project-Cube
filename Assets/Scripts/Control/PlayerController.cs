using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horInput, 0f, verInput);
        Vector3 moveDestination = transform.position + movement;
        navMeshAgent.destination = moveDestination;
    }
}
