using UnityEngine;
using System.Collections;

public class Pit_1Tr : MonoBehaviour {

	// Use this for initialization
	
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            FindObjectOfType<Camera2DFollow>().yPosRestriction = -4f;
        }
    }
}
