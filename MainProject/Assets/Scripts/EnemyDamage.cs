using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

	public float Health = 100;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerDamageBox")
        {
            Health -= 20;
        }
    }
}
