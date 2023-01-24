using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arms : MonoBehaviour
{
    private Camera cam;
    public float rate = 0.2f;
    float current, current2 = 0;
    public int gun1 = 1;
    public int gun2 = 1;
    public Transform gun1pos, gun2pos;
    public Projectile projectile;
    
    
    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
       
        Vector3 mouse_pos;
        Transform target = this.transform; //Assign to the object you want to rotate
        Vector3 object_pos;
        float angle;
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 60f; //The distance between the camera and object
        object_pos = cam.WorldToScreenPoint(target.position);
        mouse_pos.x = object_pos.x - mouse_pos.x;
        mouse_pos.y = object_pos.y - mouse_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        target.rotation = Quaternion.Euler(new Vector3(0, -angle + 90, 0));

        current -= Time.fixedDeltaTime;
        current2 -= Time.fixedDeltaTime;

       
        if (Input.GetMouseButton(1))
        {
            
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (current <= 0)
                {
                    //Transform objectHit = hit.transform;
                    Debug.Log(hit.point);
                    Projectile clone;
                    Vector3 v = hit.point;
                    v.y = gun1pos.position.y;
                    //clone = Instantiate(projectile, gun1pos.position, Quaternion.Euler(gun1pos.position - hit.point).normalized);
                    clone = Instantiate(projectile, gun1pos.position, Quaternion.Euler(gun1pos.position - v).normalized);
                    clone.transform.forward = (hit.point - gun1pos.position).normalized;
                    current = rate;
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
                    //Transform objectHit = hit.transform;
                    Debug.Log(hit.point);
                    Projectile clone;
                    Vector3 v = hit.point;
                    v.y = gun2pos.position.y;
                    //clone = Instantiate(projectile, gun1pos.position, Quaternion.Euler(gun1pos.position - hit.point).normalized);
                    clone = Instantiate(projectile, gun2pos.position, Quaternion.Euler(gun2pos.position - v).normalized);
                    clone.transform.forward = (hit.point - gun2pos.position).normalized;
                    current2 = rate;
                }
            }
        }
    }
}
