using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneController : MonoBehaviour  ,ISceneController,IUserAction{

	public PatroFactory factory;
	public GameObject player;
	public ScoreRecorder recorder;
	public PatrolActionManager actionManager ; 
	private List<GameObject> patrols;
	private bool gameover = false;
	public int now_sign = -1;

	private float playerSpeed = 3f;
	private float playerRotate = 135f;

	void Start(){
		SSDirector director = SSDirector.GetInstance ();
		director.currentSceneController = this;
		factory = Singleton<PatroFactory>.GetInstance;
		actionManager = gameObject.AddComponent<PatrolActionManager> () as PatrolActionManager;
		LoadResources ();
		recorder = Singleton<ScoreRecorder>.GetInstance;
	}

	void Update(){
		for (int i = 0; i < patrols.Count; i++) {
			patrols [i].gameObject.GetComponent<PatrolData> ().now_sign = now_sign;
		}
		//move (patrols);
	}

	public void LoadResources(){
		Instantiate (Resources.Load<GameObject> ("Prefabs/Plane"));
		player = Instantiate (Resources.Load<GameObject> ("Prefabs/Player"), new Vector3 (1,  0, 1), Quaternion.identity);
		player.transform.GetComponent<Animator> ().SetBool ("run", true);
		patrols = factory.GetPatrol ();
		for (int i = 0; i < patrols.Count; i++) {
		
			actionManager.GoPatrol (patrols [i]);
		}
	}

	public void MoveTo(float x,float z){
		if (!gameover) {
		
		//	player.GetComponent<Animator> ().SetBool ("run", true);

			player.transform.Translate(0, 0, z * playerSpeed * Time.deltaTime);
			player.transform.Rotate(0, x * playerRotate * Time.deltaTime, 0);
			if (player.transform.localEulerAngles.x != 0 || player.transform.localEulerAngles.z != 0)
			{
				player.transform.localEulerAngles = new Vector3(0, player.transform.localEulerAngles.y, 0);
			}
			if (player.transform.position.y != 0)
			{
				player.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
			}     
		}
	}


	public int GetScore()
	{
		return recorder.GetScore();
	}
		
	public bool GetGameover()
	{
		return gameover;
	}



	void OnEnable()
	{
		GameEventManager.ScoreChange += AddScore;
		GameEventManager.GameOverChange += Gameover;
	}
	void OnDisable()
	{  
		GameEventManager.ScoreChange -= AddScore;
		GameEventManager.GameOverChange -= Gameover;
	}

	void AddScore()
	{
		recorder.AddScore();
	}
	void Gameover()
	{
		gameover = true;
		Debug.Log ("gameover");
		factory.RemoveAllAnimator ();
		actionManager.DestroyAllAction();

	}

}
