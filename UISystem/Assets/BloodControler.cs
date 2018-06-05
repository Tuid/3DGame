using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BloodControler : MonoBehaviour {
	

	public  Slider slider;
	public Button button1;
	private Button b1;
	public Button button2;
	private Button b2;


	private Slider s;
	void Start (){
		s = slider.GetComponent<Slider> ();
		b1 = button1.GetComponent<Button>();
		b1.onClick.AddListener(IncreaseClick);
		b2 = button2.GetComponent<Button>();
		b2.onClick.AddListener(DecreaseClick);
	}

/* 
	void OnGUI(){
		if (GUI.Button (new Rect (200, 200, 80, 30), "Increase")) {
			IncreaseClick ();
		}
		if (GUI.Button (new Rect (200, 100, 80, 30), "Decrease")) {
			DecreaseClick ();
		}
	
	}
*/

	void IncreaseClick(){
		if(s != null){
			s.value++;
		}
	}

	void DecreaseClick(){
		if(s != null){
			s.value--;
		}
	}
}
