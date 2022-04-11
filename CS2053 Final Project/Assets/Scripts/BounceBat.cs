using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBat : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 LastVelocity;
    // Start is called before the first frame update
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            var speed = LastVelocity.magnitude;
            var direction = Vector3.Reflect(LastVelocity.normalized, other.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
    }
    // this is a test 
}
