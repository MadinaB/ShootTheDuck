using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMoveScript : MonoBehaviour {

	public Transform MouseOutlinePrefab;
	Transform MouseOutlineTransform;
	float direction = 1;

	void Start () {
		MouseOutlineTransform = Instantiate(MouseOutlinePrefab) as Transform;
	}

	void Update () {
		var mousePosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
		MouseOutlineTransform.position = new Vector3(mousePosition.x,mousePosition.y, 0F);
		var mouseX = mousePosition.x;
		if (mouseX > 0) {
			changeGunDirection (1);
			this.transform.position = new Vector3 (mousePosition.x+0.5F, this.transform.position.y, 0F);
		} else {
			changeGunDirection (-1);
			this.transform.position = new Vector3 (mousePosition.x-0.5F, this.transform.position.y, 0F);
		}

		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");

		if (shoot)
		{
			GunScript gun = GetComponent<GunScript>();
			if (gun != null)
			{
				gun.Attack(MouseOutlineTransform.position );
			}
		}
	}

	void changeGunDirection(float d){
		if(direction != d){
			direction = d;
			Vector3 newScale = this.transform.localScale;
			newScale.x *= -1;
			this.transform.localScale = newScale;
		}
	}
		
}
