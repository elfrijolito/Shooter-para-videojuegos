using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsoMaloMove : MonoBehaviour
{
    [SerializeField] private Transform Osito;
    [SerializeField] private float RangoEnemigo;
    private Rigidbody2D Rigidbody2D;
    public Animator Animator;
    public float Speed;
    public GameObject BulletPrefab;
    public GameObject point;
    private float LastShoot;
    private int Health = 3;
    private bool Grounded;

    void Start()
    {
       Rigidbody2D = GetComponent<Rigidbody2D>();
       Animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        Vector3 direction = Osito.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(0.018f, 0.018f, 0.018f);
        else transform.localScale = new Vector3(-0.018f, 0.018f, 0.018f);

         float distance = Mathf.Abs(Osito.transform.position.x - transform.position.x);

         Animator.SetBool("Grounded", Grounded);

         Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (distance < 1.5f && Time.time > LastShoot + 0.75f)
        {
            Shoot();
            LastShoot = Time.time;
        }

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

     private void Shoot()
     {
        Vector3 direction;
         if (transform.localScale.x == 0.018f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, point.transform.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
     }

      public void Hit()
    {
        Health = Health - 1;
        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }
}
