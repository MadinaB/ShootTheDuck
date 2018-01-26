﻿using System.Collections;
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
	public List<int> targetSpeeds = new List<int>(){7,12};
	public List<string> targetLayers = new List<string>(){"BigDuckLine","SmallDuckLine"};


	public int GameTargets = 10;
	public int GameTargets1 = 5;
	public int GameTargets2 = 5;
	public int GameTime = 10;
	public int GameSpeed = 10;

	public int score = 0;
	public int totalScore = 0;
	public int ducksKilled = 0;

	float timer = 0.0f;
	int seconds = 0;

	bool gameMode = true;
	bool gameStarted = false;

	void Start () {
		readTargetsData ();
		//startGame ();
	}

	void Update () {
		if (gameMode) {
			if (!gameStarted) {
				startGame ();
				gameStarted = true;
			}
			updateGame ();
			timer += Time.deltaTime;
			seconds = (int)timer % 60;
			if (seconds > GameTime) {
				destroyGame ();
				gameMode = false;
				gameStarted = false;
			}
		} else {
			startMenu();
		}
	}

	void readTargetsData(){
		GameTargets = 10;
		GameSpeed = 20;
		GameTime = 10;
		GameTargets1 = (int )GameTargets / 3;
		GameTargets2 = GameTargets - GameTargets1;
	}

	void startGame(){

		score = 0;
		totalScore = 0;
		ducksKilled = 0;

		targetAmounts = new List<int> (){ GameTargets1, GameTargets2 };

		DecorationsTransform = Instantiate(DecorationsPrefab) as Transform;
		DecorationsTransform.position = transform.position;

		RiffleTransform = Instantiate(RifflePrefab) as Transform;
		RiffleTransform.gameObject.GetComponent<GunScript>().speed = GameSpeed;

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

	void destroyGame(){
		StartCoroutine(destroyGameRoutine());
	}

	IEnumerator destroyGameRoutine(){
		foreach (Transform child in RiffleTransform)
		{
			Destroy(child.gameObject);
		}
		Destroy (RiffleTransform.gameObject);
		yield return new WaitForSeconds(1);
		foreach (Transform child in TargetObjects1Transform)
		{
			Destroy(child.gameObject);
		}
		foreach (Transform child in TargetObjects2Transform)
		{
			Destroy(child.gameObject);
		}
		yield return new WaitForSeconds(2);
		foreach (Transform child in TargetObjects1Transform)
		{
			Destroy(child.gameObject);
		}
		foreach (Transform child in TargetObjects2Transform)
		{
			Destroy(child.gameObject);
		}
		Destroy (DecorationsTransform.gameObject);
		Destroy (TargetObjects1Transform.gameObject);
		Destroy (TargetObjects2Transform.gameObject);
		Destroy (GameObject.FindWithTag("Finish"));
	}

	void startMenu(){
		DecorationsTransform = Instantiate(DecorationsPrefab) as Transform;
		DecorationsTransform.position = transform.position;

		//MenuTransform = Instantiate(MenuPrefab) as Transform;
		//MenuTransform.position = transform.position;
	}


}