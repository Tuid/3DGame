using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolFollowAction : SSAction {

	private float speed = 1.2f;
	private GameObject player;
	private PatrolData patrolData;

	private PatrolFollowAction(){
		
	}
	public static PatrolFollowAction GetSSAction(GameObject player){
		PatrolFollowAction action = CreateInstance<PatrolFollowAction> ();
		action.player = player;

		return action;
	}

	public override void Start(){
		this.enable = true;
		patrolData = this.gameobject.GetComponent<PatrolData> ();
	}
	public override void FixedUpdate(){

		Follow ();
		if (!patrolData.followedPlayer) {
			this.destory = true;

			this.callback.SSActionEvent (this, 1, this.gameobject);
		}
	}

	public void Follow(){
		transform.position = Vector3.MoveTowards (this.transform.position, player.transform.position, speed * Time.deltaTime);
		transform.LookAt (player.transform.position);
	}
}
