using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D otherCollider)
	{ 
		if (this.transform.parent != null) {
			this.transform.parent.gameObject.GetComponent<GameBackground> ().gameMode = true;
		}
	}
}
