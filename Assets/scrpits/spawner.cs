using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public spawnsphere spawnsphere;
    playermove player;
    public Transform topleft, bottomright;
    public float rate;
    float current;

    void Start()
    {
        player = FindObjectOfType(typeof(playermove)) as playermove;
        current = rate;
    }

    
    void FixedUpdate()
    {
        current -= Time.fixedDeltaTime;
        if (current <= 0)
        {
            spawnsphere clone;
            clone = Instantiate(spawnsphere, new Vector3(Random.Range(topleft.position.x, bottomright.position.x), transform.position.y, Random.Range(topleft.position.z, bottomright.position.z)), Quaternion.identity);
            clone.pm = player;
            current = rate;
        }
    }
}
