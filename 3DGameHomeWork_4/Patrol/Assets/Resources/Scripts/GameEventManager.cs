using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour {

	public delegate void ScoreEvent();
	public static event ScoreEvent ScoreChange;

	public delegate void GameOverEvent();
	public static event GameOverEvent GameOverChange;


	public void PlayerEscape(){
		if(ScoreChange != null){
			ScoreChange();
		}
	
	}

	public void PlayerGameover(){
		if (GameOverChange != null) {
		
			GameOverChange();
		}
	}
}
