using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoPatrolAction :SSAction {
	private enum Direction
	{
		EAST,NORTH,WEST,SOUTH
	}
	private PatrolData PatrolData;

	private float speed = 1.0f;
	private Direction direction=Direction.NORTH;
	private float x, z;
	private float length;
	private bool canMove =true;

	private GoPatrolAction(){
		this.enable = true;
	}

	public static GoPatrolAction GetSSAction(Vector3 position){
		GoPatrolAction action = CreateInstance<GoPatrolAction> ();
		action.x = position.x;
		action.z = position.z;
		action.length = Random.Range (4, 7);
	
		return action;
	}


	public override void FixedUpdate(){
		if (transform.localEulerAngles.x != 0 || transform.localEulerAngles.z != 0)
		{
			transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
		}            
		if (transform.position.y != 0)
		{
			transform.position = new Vector3(transform.position.x, 0, transform.position.z);
		}

		Go ();
		if (PatrolData.followedPlayer ) {

			this.destory = true;
			this.callback.SSActionEvent (this, 0, this.gameobject);
		}
	
	}

	public void Go(){
		if (canMove) {
			switch (direction) {
			case Direction.EAST:
				x += length;
				break;
			case Direction.NORTH:
				z += length;
				break;
			case Direction.WEST:
				x -= length;
				break;
			case Direction.SOUTH:
				z -= length;
				break;
			}
			canMove = false;
		}
		this.transform.LookAt (new Vector3(x,0,z));
		float distance = Vector3.Distance (this.transform.position,new Vector3(x,0,z) );
		if (distance > 0.9 ) {
			transform.position = Vector3.MoveTowards (this.transform.position, new Vector3(x,0,z),speed*Time.deltaTime);
		} else {
			direction++;
			if (direction > Direction.SOUTH) {
				direction = Direction.EAST;
			}
			canMove = true;
		}
	}
	public override  void Start(){
		this.gameobject.GetComponent<Animator>().SetBool("walk", true);
		PatrolData  = this.gameobject.GetComponent<PatrolData>();
		this.enable = true;
	}

}
