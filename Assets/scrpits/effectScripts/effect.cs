using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime;
    public bool uselifetime = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifetime -= Time.fixedDeltaTime;
        if (lifetime <= 0 && uselifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
