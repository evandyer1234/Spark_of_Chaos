using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    NavMeshAgent nma;
    public GameObject target;
    
    void Start()
    {
        nma = GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
        nma.SetDestination(target.transform.position);
    }

    
    void Update()
    {
        nma.SetDestination(target.transform.position);
    }
}
