using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetime : MonoBehaviour
{
    [SerializeField] float duration = 10f;
    

    

    private void FixedUpdate()
    {
        duration -= Time.fixedDeltaTime;
        if (duration <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
