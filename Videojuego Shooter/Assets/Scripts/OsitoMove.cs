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
    }
}
