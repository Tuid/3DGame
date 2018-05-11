using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSActionManager : MonoBehaviour,ISSActionCallback {

	private Dictionary<int,SSAction> actions = new Dictionary<int, SSAction> ();
	List<SSAction> waitAdd = new List<SSAction>();
	List<int> waitDelete = new List<int>();

	protected void Start(){
	}

	protected void Update(){
		foreach (SSAction ac in waitAdd) {
			actions [ac.GetInstanceID ()] = ac;
		}
		waitAdd.Clear ();

		foreach (KeyValuePair<int,SSAction> k in actions) {
			SSAction ac = k.Value;
			if (ac.destory) {
				waitDelete.Add (ac.GetInstanceID ());
			} else if (ac.enable) {
				ac.FixedUpdate ();
			}
		}

		foreach (int key in waitDelete) {
			SSAction ac = actions [key];
			actions.Remove (key);
			DestroyObject (ac);
		}
		waitDelete.Clear ();
	}
	public void RunAction(GameObject gameObject,SSAction action,ISSActionCallback manager){
		action.gameobject = gameObject;
		action.transform = gameObject.transform;
		action.callback = manager;
		waitAdd.Add (action);
		action.Start ();
	}



	public void SSActionEvent(SSAction source,int intParm = 0,GameObject objectParm=null){
	
		if (intParm == 0) {
		
			PatrolFollowAction follow = PatrolFollowAction.GetSSAction (objectParm.gameObject.GetComponent<PatrolData> ().player);
			this.RunAction (objectParm, follow, this);
		} else {
			GoPatrolAction go = GoPatrolAction.GetSSAction (objectParm.gameObject.GetComponent<PatrolData> ().position);
			this.RunAction (objectParm, go, this);
			Singleton<GameEventManager>.GetInstance.PlayerEscape ();
		}
	}

	public void DestoryAll(){
		foreach (KeyValuePair<int ,SSAction> kv in actions) {
			SSAction ac = kv.Value;
			ac.destory = true;
		}
	}
}
