using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 direction;
    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float z_pos = transform.position.z;
        if (z_pos < -2) {
            Destroy(gameObject);
        }
        rb.MovePosition(transform.position + direction * Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

}
