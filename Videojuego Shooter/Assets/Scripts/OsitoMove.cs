using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OsitoMove : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject point;
    private float LastShoot;
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;

    public LayerMask capaDePiso;
    public Transform sensorParaPiso;
    private bool estaEnElPiso;
    private float radioDelSensor = 0.07f;

    public int vida = 5;
    public TextMeshProUGUI vidatext;
    public string nombreNivel;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        vidatext = GameObject.Find("Vidas").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-0.018f, 0.018f, 0.018f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.018f, 0.018f, 0.018f);

        Animator.SetBool("Running", Horizontal != 0.0f);
        Animator.SetBool("Grounded", Grounded);

        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);

        if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;


        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.30f)
        {
            Shoot();
            LastShoot = Time.time;
        }

    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 0.018f) direction = Vector3.right;
        else direction = Vector3.left;

        GameObject bullet = Instantiate(BulletPrefab, point.transform.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void FixedUpdate() 
    {
        estaEnElPiso = Physics2D.OverlapCircle(sensorParaPiso.position, radioDelSensor, capaDePiso);
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D plataforma)
    {
        if (plataforma.transform.tag == "Plataforma")
        {
            transform.parent = plataforma.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D plataforma)
    {
        if (plataforma.transform.tag == "Plataforma")
        {
            transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
            vida = vida - 1;
        EscribirPuntos();

        if(vida <=0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(nombreNivel);
        }
    }

    void EscribirPuntos()
    {
        vidatext.text = "" + vida.ToString();
    }

}
