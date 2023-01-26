using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnsphere : MonoBehaviour
{
    public playermove pm;
    public enemy e;

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag != "py")
        {
            enemy clone;
            clone = Instantiate(e, transform.position, Quaternion.identity);
            clone.target = pm.gameObject;
            Destroy(this.gameObject);
        }
    }
}
