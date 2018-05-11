using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour {

	void OnCollisionEnter(Collision c){
		if (c.gameObject.tag == "Player") {
			Debug.Log ("end");
			Singleton<GameEventManager>.GetInstance.PlayerGameover();
		}
	}
}
