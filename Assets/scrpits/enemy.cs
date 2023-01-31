using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    NavMeshAgent nma;
    public GameObject target;
    public float killrange = 2f;
    
    void Start()
    {
        nma = GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
        nma.SetDestination(target.transform.position);
    }

    
    void Update()
    {
        nma.SetDestination(target.transform.position);
        /*
        if (Vector3.Distance(target.transform.position, transform.position) <= killrange)
        {

        }
        */
    }
    void OnCollisionEnter(Collision other)
    {
        playermove h = other.gameObject.GetComponent(typeof(playermove)) as playermove;

        if (h != null)
        {
            Debug.Log("hit!");
            foreach (GameData g in GameObject.FindObjectsOfType(typeof(GameData)))
            {
                g.GameOver();
            }
        }
    }
}
