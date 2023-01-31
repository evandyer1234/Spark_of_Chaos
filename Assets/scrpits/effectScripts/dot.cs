using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dot : effect
{
    public float rate = 0.1f;
    float current = 0;
    public int dam = 1;
    
    void OnTriggerStay(Collider other)
    {
        if (current <= 0)
        {
            hitable h = other.gameObject.GetComponent(typeof(hitable)) as hitable;

            if (h != null)
            {
                h.TakeDamage(dam);
                current = rate;
            }
        }
    }
}
