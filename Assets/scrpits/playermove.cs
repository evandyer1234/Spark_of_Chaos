using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public Rigidbody rb;
    public float accelerate = 20f;
    public float topspeed = 50f;
   

   
    void Start()
    {
        rb = GetComponent(typeof(Rigidbody)) as Rigidbody;
    }

    void Update()
    {
        //if (!gm.paused && !gm.isover)
        //{
            
            Vector3 dir = transform.forward;

            dir.y = 0;

            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity += dir * accelerate * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity += dir * -accelerate * Time.fixedDeltaTime;
            }
            dir = transform.right;
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity += dir * -accelerate * Time.fixedDeltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity += dir * accelerate * Time.fixedDeltaTime;
            }

        if (rb.velocity.x > topspeed)
        {
            rb.velocity = new Vector3(topspeed, rb.velocity.y, rb.velocity.z);
            
        }
        if (rb.velocity.z > topspeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, topspeed);
        }
        if (rb.velocity.x < -topspeed)
        {
            rb.velocity = new Vector3(-topspeed, rb.velocity.y, rb.velocity.z);

        }
        if (rb.velocity.z < -topspeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -topspeed);
        }

        rb.velocity *= 0.99f;
        //}
    }
}
