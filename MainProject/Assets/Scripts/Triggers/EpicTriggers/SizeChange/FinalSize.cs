using UnityEngine;
using System.Collections;

public class FinalSize : MonoBehaviour {

    Camera cam;
	void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            cam = FindObjectOfType<Camera>();
            cam.orthographicSize = 11;
            FindObjectOfType<Camera2DFollow>().yPosRestriction = -18f;
        }
    }
}
