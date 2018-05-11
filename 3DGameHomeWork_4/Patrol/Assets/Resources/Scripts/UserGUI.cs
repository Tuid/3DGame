using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour {

	// Use this for initialization
	private IUserAction action;
	void Start () {
		action = SSDirector.GetInstance ().currentSceneController as IUserAction;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float z = Input.GetAxis ("Vertical");
		action.MoveTo(x, z);
	}

	void OnGUI(){
		GUI.Label (new Rect (0, 20, 100, 30),action.GetScore().ToString());
		GUI.Label (new Rect (0, 60,100, 30), action.GetGameover ().ToString());
		if (action.GetGameover() == true) {
			GUI.Label (new Rect (400, 100,100,100), "GameOver");
			GUI.Label (new Rect (400, 200,100,100), "Score:"+action.GetScore().ToString() );
		}
	}
}
