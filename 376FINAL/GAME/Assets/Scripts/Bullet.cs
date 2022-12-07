using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private Rigidbody rb;

    public float deadSpace = 12f;

    private void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //out of the deadSpace you die
        if (transform.position.z > deadSpace)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //increase score by one
        ///
        ScoreKeeper.pointAdded(1);

        //self destroy
        Destroy(gameObject);
    }
}
