using UnityEngine;
using System.Collections;

public class nicejumptest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (GetComponent<NavMeshAgent> ().isOnOffMeshLink) {
		//}
		if (TimerSystem.Instance.CheckTimer ("sometimer", 3))
			Debug.Log ("здесь вызывается какая-то функция");
	}
}
