using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       Destroy(gameObject);
    }
}
