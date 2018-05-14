using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public int playerNumber = 1;

    [SerializeField] private int maxLife = 10;
    [SerializeField] private float groundSpeed = 10f;
    [SerializeField] private float airSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;

    [SerializeField] private GameObject attackChildobject;

    [SerializeField] private GameObject lifeUI;
    [SerializeField] private PhysicMaterial frictionMaterial;
    [SerializeField] private PhysicMaterial noFrictionMaterial;

    private Rigidbody rigidbody;
    private Collider collider;
    private TextMesh textMesh;
    private Animator animator;

    private Vector3 movement;
    private float distToGround;
    private float groundVelocity;



    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        if (lifeUI != null)
        {
            textMesh = lifeUI.GetComponent<TextMesh>();
        }
        if (attackChildobject != null)
        {
            animator = attackChildobject.GetComponent<Animator>();
        }
    }

    private void Start()
    {
        gameObject.tag = "Player" + playerNumber;
        distToGround = collider.bounds.extents.y;
        if (lifeUI != null)
        {
            UpdateLife();
        }
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



    private void Move() //Player moves left and right when stick pressed
    {
        if (Input.GetAxis("Move" + playerNumber) > 0 || Input.GetAxis("Move" + playerNumber) < 0)
        {
            rigidbody.velocity = new Vector3(Input.GetAxis("Move" + playerNumber) * groundSpeed , rigidbody.velocity.y, 0);
        }
    }

    private void Jump() //Player jumps when jump button pressed and grounded
    {
        if (Input.GetButtonDown("Jump" + playerNumber) && IsGrounded())
        {          
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce, 0);
        }
    }

    private void Flip() //Flip player when facing left
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

    private void ChangePhysicMaterial() //Change player material to no friction when player is not grounded
    {
        if (IsGrounded())
            collider.material = frictionMaterial;
        else
            collider.material = noFrictionMaterial;
    }

    private bool IsGrounded() //Check if player is grounded
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.01f);
    }

    private void UpdateLife()
    {
        textMesh.text = "";
        for (int i = 0; i < maxLife; i++)
        {
            textMesh.text += "I";
        }
    }

    private void MeleeAttack()
    {
        attackChildobject.SetActive(true);

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            //Wait until the animation stops playing
        }

        attackChildobject.SetActive(false);
    }
}
