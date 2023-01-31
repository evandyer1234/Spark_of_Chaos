using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class arms : MonoBehaviour
{
    private Camera cam;
    public float rate = 0.2f;
    float current, current2 = 0;

    public int clipsize = 70;

    int gun1ammo = 1;
    int gun2ammo = 1;

    public int gun1num = 1;
    public int gun2num = 1;

    public TextMeshProUGUI gun1vis;
    public TextMeshProUGUI gun2vis;
    public TextMeshProUGUI combovis;

    public TextMeshProUGUI gun1visammo;
    public TextMeshProUGUI gun2visammo;


    public Transform gun1pos, gun2pos;
    public Projectile projectile;
    
    
    void Start()
    {
        gun1ammo = clipsize;
        gun2ammo = clipsize;
        cam = Camera.main;
        ResetUI();
    }

    void FixedUpdate()
    {
        current -= Time.fixedDeltaTime;
        current2 -= Time.fixedDeltaTime;
    }
    
    void Update()
    {
       
        Vector3 mouse_pos;
        Transform target = this.transform; 
        Vector3 object_pos;
        float angle;
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 60f; 
        object_pos = cam.WorldToScreenPoint(target.position);
        mouse_pos.x = object_pos.x - mouse_pos.x;
        mouse_pos.y = object_pos.y - mouse_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        target.rotation = Quaternion.Euler(new Vector3(0, -angle + 90, 0));

      

       
        if (Input.GetMouseButton(1))
        {
            
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (current <= 0)
                {
                   
                    Debug.Log(hit.point);
                    Projectile clone;
                    Vector3 v = hit.point;
                    v.y = gun1pos.position.y;
                    
                    clone = Instantiate(projectile, gun1pos.position, Quaternion.Euler(gun1pos.position - v).normalized);
                    clone.transform.forward = (hit.point - gun1pos.position).normalized;
                    clone.combo = gun1num + gun2num;
                    current = rate;

                    gun2ammo--;
                    gun2visammo.text = "" + gun2ammo + "/" + clipsize;

                    if (gun2ammo <= 0)
                    {
                        gun2ammo = clipsize;
                        gun2num = Random.Range(1, 3);
                        gun2vis.text = "" + gun2num;
                        combovis.text = "" + (gun1num + gun2num);
                    }
                }
            }
        }
        if (Input.GetMouseButton(0))
        {

            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (current2 <= 0)
                {
                    
                    Debug.Log(hit.point);
                    Projectile clone;
                    Vector3 v = hit.point;
                    v.y = gun2pos.position.y;
                    
                    clone = Instantiate(projectile, gun2pos.position, Quaternion.Euler(gun2pos.position - v).normalized);
                    clone.transform.forward = (hit.point - gun2pos.position).normalized;
                    clone.combo = gun1num + gun2num;
                    current2 = rate;

                    gun1ammo--;
                    gun1visammo.text = "" + gun1ammo + "/" + clipsize;

                    if (gun1ammo <= 0)
                    {
                        gun1ammo = clipsize;
                        gun1num = Random.Range(1, 3);
                        gun1vis.text = "" + gun1num;
                        combovis.text = "" + (gun1num + gun2num);
                    }
                }
            }
        }
    }
    public void ResetUI()
    {
        gun1vis.text = "" + gun1num;
        gun2vis.text = "" + gun2num;
        combovis.text = "" + (gun1num + gun2num);
        gun1visammo.text = gun1visammo.text = "" + gun1ammo + "/" + clipsize;
        gun1visammo.text = gun2visammo.text = "" + gun2ammo + "/" + clipsize;
    }
}
