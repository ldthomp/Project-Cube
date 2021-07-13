using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Rigidbody rigidbody;
    Vector3 playerPos;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerPos = transform.position;    
    }

    void Update()
    {

        if(Input.GetKey(KeyCode.W))
        {
            print(Input.GetAxis("Horizontal") + Time.deltaTime);
            //rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            rigidbody.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            //rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            rigidbody.AddRelativeForce(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            rigidbody.AddRelativeForce(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            rigidbody.AddRelativeForce(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            ResetRBConstraints();
        }
        
    }

    private void ResetRBConstraints()
    {
        rigidbody.constraints = RigidbodyConstraints.None;
        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
