using UnityEngine;
using System.Collections;

public class SizeCh_1: MonoBehaviour {

    Camera cam;
    float size;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            cam = FindObjectOfType<Camera>();
            size = cam.orthographicSize;
            
            //while (cam.orthographicSize >= size + 1)
            //    cam.orthographicSize += 0.01f;
          
            
        }
    }
}
