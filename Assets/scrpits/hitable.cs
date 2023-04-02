using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitable : MonoBehaviour
{
    public float health;
    public Slider slider;
    public GameObject sliderparent;
    public float points = 0;
   
    
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }


    public void TakeDamage(int dam)
    {
        health -= dam;
        slider.value = health;

        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if (points != 0)
        {
            GameData gm = FindObjectOfType(typeof(GameData)) as GameData;
            if (gm != null)
            {
                gm.Addpoints(points);
            }
        }
        Destroy(sliderparent.gameObject);
        Destroy(this.gameObject);
    }
}
