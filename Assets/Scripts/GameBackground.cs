using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackground : MonoBehaviour {

	public Transform DecorationsPrefab;
	Transform decTransform;
	//public Transform [] Level1Ducks = new Transform(){DecorationsPrefab};
	//public Transform [] Level1DuckNames ={};
	//bool menuMode = true;
	public bool gameMode = false;
	public int duckKilled = 0;
	public bool kill = false;
	public int score = 0;
	public int totalScore = 0;



	void Start () {
		
	}
		
	void Update () {
		if (!gameMode) {
			StartGame ();
		}
		if (kill) {
			kill = false;
			GameObject mygameObj = Instantiate(Resources.Load("duck_brown"+duckKilled)) as GameObject;
		}
	}
		
	void StartGame(){
		gameMode = true;
		decTransform = Instantiate(DecorationsPrefab) as Transform;
		decTransform.position = transform.position;
		GameObject mygameObj = Instantiate(Resources.Load("duck_brown"+duckKilled)) as GameObject;
	}

	void DestroyGame(){
		Destroy (decTransform.gameObject);
		gameMode = false;
	}


	IEnumerator Example()
	{
		//	StartCoroutine (Example ());
		StartGame ();
		yield return new WaitForSeconds(5);
		DestroyGame ();
		yield return new WaitForSeconds(5);
	}


}
