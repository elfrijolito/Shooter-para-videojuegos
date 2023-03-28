using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsitoMove : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        Animator.SetBool("Running", Horizontal != 0.0f);
        Animator.SetBool("Grounded", Grounded);

        Debug.DrawRay(transform.position, Vector3.down * 1.5f, Color.red);

        if(Physics2D.Raycast(transform.position, Vector3.down, 1.5f))
        {
            Grounded = true;
        }
        else Grounded = false;


        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

    }


    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate() 
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

}
