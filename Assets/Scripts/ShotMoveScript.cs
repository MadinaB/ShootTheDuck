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

	bool ReachedPoint(Vector3 pos1,Vector3 pos2){
		return (LocatedTooClose(roundedFloat(pos1.x),roundedFloat(pos2.x)) && LocatedTooClose(roundedFloat(pos1.y),roundedFloat(pos2.y)));
	}

	bool LocatedTooClose(float f1, float f2){
		return (Mathf.Abs (f1 - f2) < 0.24F);
	}

	float roundedFloat(float f){
		return f = Mathf.Round(f * 10f) / 10f;
	}

	void FixedUpdate ()
	{
		if (rigidbodyComponent == null) {
			rigidbodyComponent = GetComponent<Rigidbody2D> ();
		}
		if (!ReachedPoint(this.transform.position, attackPosition)) {
			rigidbodyComponent.velocity = movement;
		} else {
			rigidbodyComponent.velocity = new Vector3(0, 0, 0);
			rigidbodyComponent.angularVelocity = 0F;
			this.GetComponent<ShotScript>().damage = 0;
		}
	}
}
