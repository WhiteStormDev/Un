using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public float speed = 5f;
    public bool TurnOnCameraScript;
    public Camera cam;
	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<Camera>();
    
	}
	
	// Update is called once per frame
	void Update () {
        if (!TurnOnCameraScript)
            return;
	    if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.I))
        {
            if (cam.orthographicSize <= 15) 
                    cam.orthographicSize += 1 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.O))
        {
            if (cam.orthographicSize >= 1.5)
                cam.orthographicSize -= 1 * Time.deltaTime;
        }
    }
}
