using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBackground : MonoBehaviour {

	public Transform TargetObjects1Prefab;
	public Transform TargetObjects2Prefab;
	public Transform DecorationsPrefab;
	public Transform RifflePrefab;

	List<Transform> TargetObjectsTransforms;
	Transform DecorationsTransform;
	Transform RiffleTransform;
	Transform TargetObjects1Transform;
	Transform TargetObjects2Transform;


	public List< List<string> >  targets = new List<List<string> >(){
		new List<string>(){"duck_brown","duck_white","duck_yellow"},
		new List<string>(){"duck_brown_small","duck_white_small","duck_yellow_small"}	
	};
	public List<int> targetAmounts = new List<int>(){3,5};
	public List<int> targetSpeeds = new List<int>(){3,20};
	public List<string> targetLayers = new List<string>(){"BigDuckLine","SmallDuckLine"};
	int targetsSize = 2;

	public int score = 0;
	public int totalScore = 0;
	public int ducksKilled = 0;

	void Start () {
		startGame ();
	}

	void Update () {
		updateGame ();
	}

	void startGame(){
		
		DecorationsTransform = Instantiate(DecorationsPrefab) as Transform;
		DecorationsTransform.position = transform.position;

		RiffleTransform = Instantiate(RifflePrefab) as Transform;

		TargetObjects1Transform = Instantiate (TargetObjects1Prefab) as Transform;
		TargetObjects1Transform.gameObject.GetComponent<TargetSubset>().instantinateTargets(targets[0], targetLayers[0], targetAmounts[0], targetSpeeds[0]);
		TargetObjects1Transform.SetParent (this.transform);
		TargetObjects1Transform.position = transform.position;

		TargetObjects2Transform = (Instantiate (TargetObjects2Prefab) as Transform);
		TargetObjects2Transform.gameObject.GetComponent<TargetSubset>().instantinateTargets(targets[1], targetLayers[1], targetAmounts[1], targetSpeeds[1]);
		TargetObjects2Transform.SetParent (this.transform);
		TargetObjects2Transform.position = transform.position;

		/*for (int i = 0; i < targetsSize; i++) {
			TargetObjectsTransforms.Add (Instantiate (TargetObjectsPrefab) as Transform);
			TargetObjectsTransforms[i].gameObject.GetComponent<TargetSubset>().instantinateTargets(targets[i], targetLayers[i], targetAmounts[i], targetSpeeds[i]);

		}*/
	}
	void updateGame(){
		
		TargetObjects1Transform.gameObject.GetComponent<TargetSubset>().updateTargets();
		TargetObjects2Transform.gameObject.GetComponent<TargetSubset>().updateTargets(); 
		/*
		for(int i = 0; i<TargetObjectsTransforms.Count; i++){
			TargetObjectsTransforms[i].gameObject.GetComponent<TargetSubset>().updateTargets();
		}
		*/
	
	}

}