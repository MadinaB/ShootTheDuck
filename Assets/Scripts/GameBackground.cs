using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackground : MonoBehaviour {

	public Transform DecorationsPrefab;
	Transform decTransform;
	//bool menuMode = true;
	bool gameMode = false;


	void Start () {
		
	}
		
	void Update () {
		
		if (!gameMode) {
			StartGame ();
		}
	}
		
	void StartGame(){
		gameMode = true;
		decTransform = Instantiate(DecorationsPrefab) as Transform;
		decTransform.position = transform.position;
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
