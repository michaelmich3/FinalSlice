using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float groundSpeed = 10f;
    [SerializeField] private float airSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;

    [SerializeField] private PhysicMaterial frictionMaterial;
    [SerializeField] private PhysicMaterial noFrictionMaterial;

    private Rigidbody rigidbody;
    private Collider collider;
    private Vector3 movement;
    private float distToGround;
    private float groundVelocity;



    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    private void Start()
    {
        distToGround = collider.bounds.extents.y;
    }

    private void Update()
    {
        Jump();
        ChangePhysicMaterial();
    }

    private void FixedUpdate()
    {
        Move();
        Flip();
    }



    private void Move()
    {
        if (Input.GetButton("Move") || Input.GetAxis("Move") > 0 || Input.GetAxis("Move") < 0)
        {
            rigidbody.velocity = new Vector3(Input.GetAxis("Move") * groundSpeed , rigidbody.velocity.y, 0);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {          
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce, 0);
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

    private void ChangePhysicMaterial()
    {
        if (IsGrounded())
            collider.material = frictionMaterial;
        else
            collider.material = noFrictionMaterial;
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.01f);
    }
}
