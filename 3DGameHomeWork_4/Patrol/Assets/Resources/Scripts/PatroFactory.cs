using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatroFactory : MonoBehaviour {

	public 	GameObject patrolPrefab;
	//bao cun shiyong de xunluozhe
	//bao cun weishiyong de xunluozhe
	private List<GameObject> used = new List<GameObject>();
	private List<PatrolData> wait = new List<PatrolData>();
	private Vector3[] vector = new Vector3[3];
	public FirstSceneController sceneControler;
	//chushihua
	private void Awake(){
		Debug.Log (patrolPrefab);
	}



	//dedao xunluozhe ziyuan
	public List<GameObject> GetPatrol(){

		int[] pos_x = { 10, 8, -5 };
		int[] pos_y =  { 6, 3, -7};
		for (int i = 0; i < 3; i++) {
			vector[i] = new Vector3 (pos_x [i], 0, pos_y [i]);
			patrolPrefab = GameObject.Instantiate<GameObject> (Resources.Load<GameObject>("Prefabs/Patrol"), Vector3.zero, Quaternion.identity);
			patrolPrefab.transform.position = vector [i];
			patrolPrefab.GetComponent<PatrolData> ().sign = i + 1;
			patrolPrefab.GetComponent<PatrolData> ().position = vector [i];
			used.Add (patrolPrefab);
		}
			
		return used;
	}
	public void RemoveAllAnimator(){
		for (int i = 0; i > used.Count; i++) {
			used [i].gameObject.transform.GetComponent<Animator> ().SetBool ("walk", false);
		}
	
	}

	public void remove(){
		for (int i = 0; i > used.Count; i++) {
			used.Remove (used [i]);
		}
	}
}
