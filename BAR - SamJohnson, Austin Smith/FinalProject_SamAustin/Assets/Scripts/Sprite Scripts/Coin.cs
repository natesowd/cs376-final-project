using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector2 ForwardVelocity => new Vector2(-.8f, 0.0f);

    public Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreManager.ScorePoints(5);
            ItemManager.AlterItems("coin", 10);
            Destruct();
        }
    }

    void Destruct()
    {
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destruct();

    }
    void FixedUpdate()
    {
        if (rigidBody)
        {
            rigidBody.AddForce(ForwardVelocity);
        }

    }
}
