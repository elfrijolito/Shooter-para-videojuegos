using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private GameObject efectoImpacto;
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemigo")
        {
            Instantiate(efectoImpacto, transform.position, Quaternion.identity);
        }

        if (collision.tag == "Player")
        {
            Instantiate(efectoImpacto, transform.position, Quaternion.identity);
        }

        if (collision.tag == "Escenario")
        {
            Instantiate(efectoImpacto, transform.position, Quaternion.identity);
        }

        if (collision.tag == "Roboto")
        {
            Instantiate(efectoImpacto, transform.position, Quaternion.identity);
        }

        OsoMalo osoMalo = collision.GetComponent<OsoMalo>();
        OsoMaloMove osoMaloMove = collision.GetComponent<OsoMaloMove>();
        Roboto roboto = collision.GetComponent<Roboto>();

        if (osoMalo != null)
        {
            osoMalo.Hit();
        }

        if (osoMaloMove != null)
        {
            osoMaloMove.Hit();
        }

        if (roboto != null)
        {
            roboto.Hit();
        }

        DestroyBullet();
    }

}
