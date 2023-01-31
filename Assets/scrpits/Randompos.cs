using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randompos : MonoBehaviour
{
    public Transform tl, br;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Random.Range(tl.position.x, br.position.x), Random.Range(tl.position.y, br.position.y), transform.position.z);
    }
}
