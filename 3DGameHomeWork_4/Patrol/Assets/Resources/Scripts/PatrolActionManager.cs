using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolActionManager : SSActionManager {

	private GoPatrolAction go;
	public void GoPatrol(GameObject patrol){
		go = GoPatrolAction.GetSSAction (patrol.transform.position);
		this.RunAction (patrol, go, this);
	}

	public void DestroyAllAction(){
		DestoryAll ();
	}
}
