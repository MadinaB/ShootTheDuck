using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMoveScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(0, 1);
	public Vector3 attackPosition;

	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	void Update()
	{
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}

	void FixedUpdate ()
	{
		if (rigidbodyComponent == null) {
			rigidbodyComponent = GetComponent<Rigidbody2D> ();
		}
	//	if (this.transform.position != attackPosition) {
			rigidbodyComponent.velocity = movement;
		//} else {
			//rigidbodyComponent.velocity = new Vector3(0, 0, 0);
			//rigidbodyComponent.angularVelocity = 0F;
	//	}
	}
}
