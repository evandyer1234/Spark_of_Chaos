using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitable : MonoBehaviour
{
    public float health;
    public Slider slider;
    public GameObject sliderparent;
   
    
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    
    void Update()
    {
       
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

    public void Die()
    {
        Destroy(sliderparent.gameObject);
        Destroy(this.gameObject);
    }
}
