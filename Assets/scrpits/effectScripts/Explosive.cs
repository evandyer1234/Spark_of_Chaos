using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : effect
{
    public int damage = 5;
   
    private void OnTriggerEnter(Collider other)
    {
        hitable h = other.gameObject.GetComponent(typeof(hitable)) as hitable;

        if (h != null)
        {
            
            h.TakeDamage(damage);
        }
    }
}
