using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        transform.SetParent(null);
    }
    void Update()
    {
        transform.position = target.position;
    }
}
