﻿using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {

        }
    }
}
