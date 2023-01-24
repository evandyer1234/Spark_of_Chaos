using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int combo;
    public float speed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent(typeof(Rigidbody)) as Rigidbody;
    }

    
    void Update()
    {
        rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
        //transform.up = Vector3.forward;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}
