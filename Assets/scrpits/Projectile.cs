using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int combo;
    public float speed;
    Rigidbody rb;
    public float lifetime = 20f;
    public int damage = 1;
    public List<effect> effects = new List<effect>();

    void Start()
    {
        rb = GetComponent(typeof(Rigidbody)) as Rigidbody;
    }
    
    void Update()
    {
        rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
        
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);

        lifetime -= Time.fixedDeltaTime;
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        hitable h = other.gameObject.GetComponent(typeof(hitable)) as hitable;

        if (h != null)
        {
            effect();
            h.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        Projectile p = other.GetComponent(typeof(Projectile)) as Projectile;
        if (p != null)
        {
            effect();
            Destroy(this.gameObject);
        }
    }
    public void effect()
    {
        effect clone;
        if (combo != 0)
        {
            clone = Instantiate(effects[combo], transform.position, transform.rotation);
        }
    }
}
