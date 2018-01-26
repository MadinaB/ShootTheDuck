using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSubset : MonoBehaviour {

	public static TargetSubset Instance;
	public List<string> targetResources;  
	public int targetAmount;
	public int speed;
	public bool targetKilled;
	public int targetScore;

	private List<GameObject>  targets;
	private float targetMaxRandomIndex;	
	public string targetLayer;
	private bool targetsSetted;
	private string targetTag;
	private int leftBorder; // TODO(): change to depend on Screen width listener
	private int rightBorder; // TODO(): change to depend on Screen width listener


	public void instantinateTargets (List<string> targetResources, string targetLayer, int targetAmount,int speed) {
		this.leftBorder = -11;
		this.rightBorder = 11;
		this.targetTag = "DeleteOnExit";
		this.targetKilled = false;
		this.targetsSetted = false;

		this.targetLayer = targetLayer;
		this.targetAmount = targetAmount;
		this.targetResources = targetResources; 
		this.speed = speed;
		this.targetScore = 0;

		this.targetMaxRandomIndex = (targetResources.Count - 0.1F);
		this.targets = new List<GameObject>();
	}

	public void updateTargets(){
		if (targetResources.Count > 0) {
			if (!targetsSetted) {
				targetsSetted = true;
				createTargets ();
			}
			if (targetKilled) {
				targetKilled = false;
				createTarget ();
				updateScore ();
			}
		}
	}

	void updateScore(){
		if (this.transform.parent != null) {
			this.transform.parent.gameObject.GetComponent<GameBackground> ().ducksKilled += 1;
		}

	}


	void destroyTargets(){
		for(int i=0; i<targets.Count; i++){
			if (targets[i] != null) {
				Destroy(targets[i]);
			}
		}
	}

	void createTargets(){
		StartCoroutine(createTargetsRoutine());
	}

	IEnumerator createTargetsRoutine()
	{
		for (int i = 0; i < targetAmount; i++) {
			createTarget();
			yield return new WaitForSeconds((int)Random.Range (1.0F, 5.0F));
		}
	}

	void createTarget(){
		GameObject myTarget = Instantiate(Resources.Load(getRandomTarget())) as GameObject;
		myTarget.GetComponent<SpriteRenderer>().sortingLayerName = targetLayer;
		myTarget.transform.position = getRandomPosition (myTarget.transform.position);
		myTarget.transform.SetParent (this.transform);
		myTarget.transform.GetComponent<DuckMoveScript>().speed = new Vector2 (speed, 0);
		targets.Add(myTarget);

	}


	string getRandomTarget(){
		int index = (int)Random.Range (0.0F, targetMaxRandomIndex);
		return targetResources[index];
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
