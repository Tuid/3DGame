using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCollide : MonoBehaviour {

	void OnTriggerEnter(Collider collider){
		if (collider.gameObject.tag == "Player") {
			Debug.Log ("in");
			this.gameObject.transform.parent.GetComponent<PatrolData> ().followedPlayer = true;
			this.gameObject.transform.parent.GetComponent<PatrolData> ().player = collider.gameObject;
		}
	}

	void OnTriggerExit(Collider c){
		if (c.gameObject.tag == "Player") {
			Debug.Log ("out");
			this.gameObject.transform.parent.GetComponent<PatrolData> ().followedPlayer = false;
			this.gameObject.transform.parent.GetComponent<PatrolData> ().player = null;

		}
	}

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Player") {
			Debug.Log ("death");
			Singleton<GameEventManager>.GetInstance.PlayerGameover();
		}
	}
}
