using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crossfix : effect
{
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;
    }
    private void Awake()
    {
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        Debug.Log(transform.rotation.eulerAngles);
    }
}
