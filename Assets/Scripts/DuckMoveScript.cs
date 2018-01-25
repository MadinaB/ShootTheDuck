using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMoveScript : MonoBehaviour {

	public Vector2 speed = new Vector2(10, 10);
	public Vector2 direction = new Vector2(1, 0);
	public Vector3 position = new Vector3(0, -1, 0);
	//public float layer = 0;
	public bool DirectionOnChange = true;

	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;
	private static Vector3 stageDimensions;
	private float BorderLeft;
	private float BorderRight;

	void Start(){
		Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
		BorderLeft = stageDimensions.x * (-1);
		BorderRight = stageDimensions.x;
	}

	void Update()
	{
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}

	void FixedUpdate()
	{
		if (rigidbodyComponent == null) {
			rigidbodyComponent = GetComponent<Rigidbody2D> ();
		}
		changeDirectionOnCameraExit ();
		rigidbodyComponent.velocity = movement;
	}

	void changeDirectionOnCameraExit(){
		if (BorderLeftReached() &&  (direction.x != 1)) {
			changeDuckDirection();
			changeDuckFace();
		}

		if (BorderRightReached() && (direction.x != -1)) {
			changeDuckDirection();
			changeDuckFace();
		}
	}

	bool BorderLeftReached(){
		return ((transform.position.x) < BorderLeft);
	}

	bool BorderRightReached(){
		return ((transform.position.x) > BorderRight);
	}

	void changeDuckDirection(){
		Vector2 newDirection = new Vector2(direction.x*(-1),direction.y);
		direction = newDirection;
	}
	void changeDuckFace(){
		Vector3 newScale = this.transform.localScale;
		newScale.x *= -1;
		this.transform.localScale = newScale;
	}

}
