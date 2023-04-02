using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputcheck : MonoBehaviour
{
    
   
    void Update()
    {
        if (Input.GetKey(KeyCode.U) && Input.GetKey(KeyCode.I) && Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.P))
        {
            WipeScore();
        }
    }

    public void WipeScore()
    {
        PlayerPrefs.SetString("PlayerName", "None");
        PlayerPrefs.SetInt("PlayerScore", 0);
    }
}
