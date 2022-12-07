using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float ThresholdForce = 2;

    public GameObject ExplosionPrefab;

    public float EnginePower = 1;

    public float lastFireTime = 1;

    public float ProjectileVelocity = 10;

    public float ProjectileMass = .3f;

    public float CoolDownTime = 10;

    private Vector2 ForwardVelocity => new Vector2(-.3f, 0.0f);

    public Rigidbody2D rigidBody;

    public GameObject ProjectilePrefab;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.time > lastFireTime)
        {
            Fire();

            lastFireTime += CoolDownTime;
        }
    }

    void FixedUpdate ()
    {   
        if (rigidBody)
        {
            rigidBody.AddForce(ForwardVelocity);
        }
        
    }

    private void Fire()
    {
        Rigidbody2D ProjectileBody = Instantiate(ProjectilePrefab, rigidBody.transform.position + new Vector3(-2.5f, 0.0f, 0.0f), Quaternion.identity).GetComponent<Rigidbody2D>();
        ProjectileBody.velocity = ProjectileVelocity * new Vector2(-0.5f, 0.0f);
        ProjectileBody.mass = ProjectileMass;
    }

    void Destruct()
    {
        Destroy(gameObject);
        ScoreManager.ScorePoints(15);
    }

    void Explode()
    {
        GetComponent<SpriteRenderer>().enabled = false;

        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity, transform.parent);

        Invoke("Destruct", 0.1f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyLaser")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
        }

        else if (collision.relativeVelocity.magnitude > ThresholdForce)
        {
            Explode();
            GetComponent<AudioSource>().Play(0);
        }
    }
}
