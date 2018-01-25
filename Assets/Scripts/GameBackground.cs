using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackground : MonoBehaviour {

	public Transform DecorationsPrefab;
	Transform decTransform;
	public string [] bigDucks = {"duck_brown","duck_white","duck_yellow"}; 
	public bool gameMode = false;
	public string duck_Layer = "DuckLineForward2";
	public bool kill = false;
	public int score = 0;
	public int totalScore = 0;
	public int leftBorder = -11;
	public int rightBorder = 11;



	void Start () {
		// when reply press start
	}


	void Update () {
		if (!gameMode) {
			StartGame ();
		}
		if (kill) {
			kill = false;
			createBigDuck (duck_Layer);
		}
	}
		
	void StartGame(){
		gameMode = true;
		decTransform = Instantiate(DecorationsPrefab) as Transform;
		decTransform.position = transform.position;
		StartCoroutine ( CreateBigDucks());

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

	void getRandomSmallDuck(){

	}

	void getRandomTargetCircle(){

	}

	IEnumerator CreateBigDucks()
	{
		//	StartCoroutine ( CreateSmallDucks());
		for (int i = 0; i < 3; i++) {
			createBigDuck ("BigDuckLine");
			yield return new WaitForSeconds((int)Random.Range (1.0F, 5.99F));
		}
	}

	void createBigDuck(string duck_Layer){
		GameObject mygameObj = Instantiate(Resources.Load(getRandomBigDuck())) as GameObject;
		mygameObj.GetComponent<SpriteRenderer>().sortingLayerName = duck_Layer;
		mygameObj.transform.position = getRandomPosition (mygameObj.transform.position);
	}

	string getRandomBigDuck(){
		int index = (int)Random.Range (0.0F, 2.99F);
		return bigDucks[index];
	}

	Vector3 getRandomPosition(Vector3 position){
		int index = (int)Random.Range (0.0F, 1.99F);
		if (index == 0) {
			return new Vector3 (leftBorder, position.y, position.z);
		} else {
			return new Vector3 (rightBorder, position.y, position.z);
		}

	}



}
