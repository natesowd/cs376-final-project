using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody body;
    private float xMin = -10f;
    private float xMax = 10f;
    private float yMin = -4;
    private float yMax = 7f;
    private float offset = 0f;
    private bool alive = true;
    private float time_recorder;

    public float moveSpeed = 1f;
    public int healthBar = 10;
    public GameObject bulletPrefab;
    public float bulletSpeed = 15f;
    public float CoolDownTime = 0.0001f;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        time_recorder = Time.time;
        //HealthBar.showingHealth(healthBar);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        bool fire = Input.GetButton("Fire1");
        if (time_recorder < Time.time)
        {
            //instantiate the prefab here
            if (fire)
            {
                shoot();
                //audioSource.PlayOneShot(shooting, 0.7F);
            }
            time_recorder += CoolDownTime;
        }
    }
    void Move()
    {
        var Hor = Input.GetAxis("Horizontal");
        var Ver = Input.GetAxis("Vertical");
        var direction = new Vector3(Hor / 5, Ver / 5, 0);
        direction *= moveSpeed;
        var pos = this.body.position;
        var res = direction + pos;
        //bounded
        if (res.x < xMin)
        {
            res.x = xMin + offset;
        }
        if (res.x > xMax)
        {
            res.x = xMax - offset;
        }
        if (res.y < yMin)
        {
            res.y = yMin + offset;
        }
        if (res.y > yMax)
        {
            res.y = yMax - offset;
        }
        body.MovePosition(res);
    }

    void shoot()
    {
        //Instantiate an bullet
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 0, 1f), Quaternion.identity);
        //provide the bullet with a certain speed on the Z-axis
        Rigidbody rbBullet = bullet.GetComponent<Rigidbody>();
        rbBullet.velocity = new Vector3(transform.position.x, transform.position.y, bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (alive)
        {
            healthBar--;
            HealthBar.showingHealth(healthBar);
            if (healthBar <= 0)
            {
                alive = false;
                Destroy(gameObject);
            }
        }
    }
}
