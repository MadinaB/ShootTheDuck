using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {

	Animator m_Animator;
	float m_MySliderValue;

	void Start()
	{
		m_Animator = gameObject.GetComponent<Animator>();
	}

	void OnGUI()
	{
		m_Animator.speed = 0.13F;
	}
}