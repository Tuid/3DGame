using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMGUI : MonoBehaviour {

	public float value = 0;
	public float Max = 10;
	public float Min = 0;
	public GUISkin skin;


	void OnGUI ()
	{
		GUI.skin = skin;
		if (GUI.Button (new Rect (200, 100, 80, 30), "Increase")) {
			if(value< Max)
				value++;
		}
		if (GUI.Button (new Rect (200, 200, 80, 30), "Decrease")) {
			if(value>Min)
			value--;
		}
		GUI.skin = skin;
		//GUI.Box (new Rect (300, 200, 100, 30), "good");
		GUI.HorizontalScrollbar (new Rect (300, 200, 100, 200), 0, value, Min, Max);

	}
}
