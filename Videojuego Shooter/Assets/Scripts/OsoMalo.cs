using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsoMalo : MonoBehaviour
{
    public GameObject Osito;
    public GameObject BulletPrefab;
    public GameObject point;
    private float LastShoot;
    private int Health = 3;

    void Update()
    {
        Vector3 direction = Osito.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(0.018f, 0.018f, 0.018f);
        else transform.localScale = new Vector3(-0.018f, 0.018f, 0.018f);

        float distance = Mathf.Abs(Osito.transform.position.x - transform.position.x);

        if(distance < 1.5f && Time.time > LastShoot + 0.75f)
        {
            Shoot();
            LastShoot = Time.time;
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
        Health = Health -1;
        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }
}
