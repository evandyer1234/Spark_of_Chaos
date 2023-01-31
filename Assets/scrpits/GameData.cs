using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public GameObject pausemenu;
   
    void Start()
    {
        if (pausemenu != null)
        {
            pausemenu.SetActive(false);
        }
    }

    
    void Update()
    {
        
    }
}
