using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Vector3 destination;
    Rigidbody rigidbody;
    Vector3 playerPos;
    NavMeshAgent navMeshAgent;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerPos = transform.position;
        navMeshAgent = GetComponent<NavMeshAgent>();
        destination = Vector3.forward;

    }

    void Update()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horInput, 0f, verInput);
        Vector3 moveDestination = transform.position + movement;
        navMeshAgent.destination = moveDestination;
        //if(Input.GetKey(KeyCode.W))
        //{
        //    print(Input.GetAxis("Horizontal") + Time.deltaTime);
        //    //rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        //    //rigidbody.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
        //    navMeshAgent.destination = destination * speed * Time.deltaTime;

        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    //rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        //    //rigidbody.AddRelativeForce(Vector3.left * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    //rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        //    //rigidbody.AddRelativeForce(Vector3.back * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    //rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        //    //rigidbody.AddRelativeForce(Vector3.right * speed * Time.deltaTime);
        //}
        ////else
        ////{
        ////    ResetRBConstraints();
        ////}

    }

    private void ResetRBConstraints()
    {
        rigidbody.constraints = RigidbodyConstraints.None;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
