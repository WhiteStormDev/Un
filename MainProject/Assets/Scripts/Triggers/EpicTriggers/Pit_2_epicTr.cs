using UnityEngine;
using System.Collections;

public class Pit_2_epicTr : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            FindObjectOfType<Camera2DFollow>().yPosRestriction = -23f;
        }
    }
}
