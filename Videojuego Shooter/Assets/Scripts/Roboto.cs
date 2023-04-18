using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roboto : MonoBehaviour
{
    [SerializeField] private GameObject efectoMuerte;
    [SerializeField] private Transform Osito;
    [SerializeField] private float RangoEnemigo;
    private Rigidbody2D Rigidbody2D;
    public Animator Animator;
    public GameObject point;
    public float Speed;
    private int Health = 4;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        Vector3 direction = Osito.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(-0.04f, 0.04f, 0.04f);
        else transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);

         float distance = Mathf.Abs(Osito.transform.position.x - transform.position.x);

         float distanciaPlayer = Vector2.Distance(transform.position, Osito.position);

         if (distanciaPlayer < RangoEnemigo)
        {
            PerseguirJugador();
            Animator.SetFloat("Velocidad", 1);
        }
 
        else
        {
            NoPerseguir();
            Animator.SetFloat("Velocidad", 0);
        }
    }

    private void NoPerseguir()
    {
        Rigidbody2D.velocity = Vector2.zero;
    }

    private void PerseguirJugador()
    {
        if (transform.position.x < Osito.position.x)
        {
            Rigidbody2D.velocity = new Vector2(Speed, 0f);
        }
        else if(transform.position.x > Osito.position.x)
        {
            Rigidbody2D.velocity = new Vector2(-Speed, 0f);
        }
    }

    public void Hit()
    {
        Health = Health - 1;
        if (Health == 0)
        {
            Instantiate(efectoMuerte, point.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Vacio")
        {
            Instantiate(efectoMuerte, point.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
