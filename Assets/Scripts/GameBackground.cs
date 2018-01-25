using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackground : MonoBehaviour {

	public Transform DecorationsPrefab;
	Transform decTransform;
	public Transform RifflePrefab;
	Transform riffleTransform;
	public Transform ScriptsPrefab;
	Transform scriptsTransform;

	public static string [] bigDucks = {"duck_brown","duck_white","duck_yellow"}; 
	public static string [] smallDucks = {"duck_brown_small","duck_white_small","duck_yellow_small" };
	public static string [] targetCircles ={ };

	public static float ranmaxBigDuck = ((float)bigDucks.Length - 0.1F);
	public static float ranmaxSmallDuck = ((float)smallDucks.Length - 0.1F);
	public static float ranmaxTargetCircles = ((float)targetCircles.Length - 0.1F);

	public int bigDucksAmount = 3;
	public int smallDucksAmount = 5;
	public int targetCirclesAmount = 0;

	public string bigDuckLayer = "BigDuckLine";
	public string smallDuckLayer = "SmallDuckLine";
	public string targetCircleLayer = "CircleTargetLine";
	
	public bool smallDuckKilled = false;
	public bool bigDuckKilled = false;
	public bool targetCircleKilled = false;


	public int leftBorder = -11;
	public int rightBorder = 11;
	public bool gameMode = true;
	public bool gameStarted = false;
	public int score = 0;
	public int totalScore = 0;
	public int ducksKilled = 0;

	private string OnDelete ="DeleteOnExit";

	void Start () {
		decTransform = Instantiate(DecorationsPrefab) as Transform;
		decTransform.position = transform.position;
		
	}
	void Update () {
		if (gameMode) {
			playTheGame ();
		} else {
			StartButton();
		}
			
	}
	void InitializeAllFields (){
		score = 0;
		totalScore = 0;
		ducksKilled = 0;
		smallDuckKilled = false;
		bigDuckKilled = false;
		targetCircleKilled = false;
		bigDucksAmount = 3;
		smallDucksAmount = 5;
		targetCirclesAmount = 0;
	}

	void StartButton(){
		
	}

	void destroyStartButton(){

	}

	void playTheGame(){
		if (!gameStarted) {
			destroyStartButton ();
			StartGame ();
		}
		else if(score>10){
			DestroyGame ();
		}
		updateDucks ();
	}

	void updateDucks (){
		if (bigDuckKilled) {
			bigDuckKilled = false;
			createBigDuck ();
		} else if (smallDuckKilled) {
			smallDuckKilled = false;
			createSmallDuck ();
		}
		else if (targetCircleKilled) {
			targetCircleKilled = false;
			createTargetCircle ();
		}
	}
		
	void StartGame(){
		InitializeAllFields ();
		gameStarted = true;

		riffleTransform = Instantiate (RifflePrefab) as Transform;

		scriptsTransform = Instantiate(ScriptsPrefab) as Transform;

		StartCoroutine ( CreateBigDucks());
		StartCoroutine ( CreateSmallDucks());
	}


	void DestroyGame(){
		Destroy (riffleTransform.gameObject);
		Destroy (scriptsTransform.gameObject);
		StartCoroutine (killTheDucks ());
	}

	void killDucks(){
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(OnDelete);
		for (int i = 0; i < gameObjects.Length; i++) {
			Destroy (gameObjects [i]);
		}
		gameMode = false;
	}

	IEnumerator killTheDucks()
	{
		killDucks ();
		yield return new WaitForSeconds (1);
		killDucks ();
		yield return new WaitForSeconds (1);
		killDucks ();
		yield return new WaitForSeconds (1);
		killDucks ();
	}

	IEnumerator CreateBigDucks()
	{
		for (int i = 0; i < bigDucksAmount; i++) {
			createBigDuck ();
			yield return new WaitForSeconds((int)Random.Range (1.0F, 5.0F));
		}
	}

	IEnumerator CreateSmallDucks()
	{
		for (int i = 0; i < smallDucksAmount; i++) {
			createSmallDuck ();
			yield return new WaitForSeconds((int)Random.Range (1.0F, 5.0F));
		}
	}

	void createBigDuck(){
		GameObject mygameObj = Instantiate(Resources.Load(getRandomBigDuck())) as GameObject;
		mygameObj.GetComponent<SpriteRenderer>().sortingLayerName = bigDuckLayer;
		mygameObj.transform.position = getRandomPosition (mygameObj.transform.position);
	}

	void createSmallDuck(){
		GameObject mygameObj = Instantiate(Resources.Load(getRandomSmallDuck())) as GameObject;
		mygameObj.GetComponent<SpriteRenderer>().sortingLayerName = smallDuckLayer;
		mygameObj.transform.position = getRandomPosition (mygameObj.transform.position);
	}

	void createTargetCircle(){
		//	GameObject mygameObj = Instantiate(Resources.Load(getRandomTargetCircle())) as GameObject;
	//	mygameObj.GetComponent<SpriteRenderer>().sortingLayerName =  targetCircleLayer;
	//	mygameObj.transform.position = getRandomPosition (mygameObj.transform.position);
	}


	string getRandomBigDuck(){
		int index = (int)Random.Range (0.0F, ranmaxBigDuck);
		return bigDucks[index];
	}

	string getRandomSmallDuck(){
		int index = (int)Random.Range (0.0F, ranmaxSmallDuck);
		return smallDucks[index];
	}

	string getRandomTargetCircle(){
		int index = (int)Random.Range (0.0F, ranmaxTargetCircles);
		return targetCircles[index];
	}

	Vector3 getRandomPosition(Vector3 position){
		int index = (int)Random.Range (0.0F, 1.99F);
		if (index == 0) {
			return new Vector3 (leftBorder, position.y, position.z);
		} else {
			return new Vector3 (rightBorder, position.y, position.z);
		}

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
