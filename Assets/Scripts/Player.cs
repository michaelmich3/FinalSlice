using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpSpeed = 100f;

    private Rigidbody rigidbody;
    private Transform transform;

    private Vector3 movement;
    private bool isFalling = false;
    


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
        Flip();
    }



    private void Move()
    {
        movement = new Vector3(Input.GetAxis("Move"), 0, 0);
        rigidbody.velocity = movement * speed;
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("jumped");
            rigidbody.AddForce(Vector3.up * jumpSpeed);
        }
    }

    private void Flip()
    {
        if (rigidbody.velocity.x < 0)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }
        else if (rigidbody.velocity.x > 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
    }
}
