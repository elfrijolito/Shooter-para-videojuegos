using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    private Animator anim;
    public float jumpForce;

    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("entrada");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

}
