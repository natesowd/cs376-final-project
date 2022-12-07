using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public GameObject ProjectilePrefab;

    public GameObject LaserPrefab;

    public Rigidbody2D playerBody;

    public float ProjectileVelocity = 10;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Manoeuvre();
        Fire();

        if (transform.position.y < -4.15f)
        {
            transform.position = new Vector2(transform.position.x, -4.15f);
        }

        if (transform.position.y > 4.15f)
        {
            transform.position = new Vector2(transform.position.x, 4.15f);
        }

        if (transform.position.x < 58.5f)
        {
            transform.position = new Vector2(58.5f, transform.position.y);
        }

        if (transform.position.x > 64.5f)
        {
            transform.position = new Vector2(64.5f, transform.position.y);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());

        if (collision.gameObject.tag != "Coin")
        {
            HealthManager.ChangeHealth(-10.0f);
        }
    }

    void Manoeuvre()
    {
        Vector2 movement_vector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        playerBody.AddForce(movement_vector);
    }

    void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (ItemManager.MissileCount >= 1)
            {
                ItemManager.AlterItems("missile", -1);
                FireProjectile();
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (LaserManager.CurrentLength > 20.0f)
            {
                FireLaser();
            }
            
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            if (ItemManager.HeartCount >= 1)
            {
                ItemManager.AlterItems("heart", -1);
                HealthManager.ChangeHealth(20.0f);
            }
        }
    }

    private void FireProjectile()
    {
        Instantiate(ProjectilePrefab, playerBody.transform.position + transform.right + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = ProjectileVelocity * transform.right;
    }

    private void FireLaser()
    {
        Instantiate(LaserPrefab, playerBody.transform.position + transform.right + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity).GetComponent<Rigidbody2D>().velocity = ProjectileVelocity * transform.right;
        LaserManager.ChangeEnergy(-20.0f);
    }
}
