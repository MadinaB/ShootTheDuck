using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	public Transform shotPrefab;
	public float shootingRate = 0.25f;
	public int speed = 10;
	private float shootCooldown;

	void Start()
	{
		shootCooldown = 0f;
	}

	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	public void Attack(Vector3 attackPosition)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			var shotTransform = Instantiate(shotPrefab) as Transform;
			shotTransform.position = transform.position;

			ShotMoveScript move = shotTransform.gameObject.GetComponent<ShotMoveScript>();
			if (move != null)
			{
				move.attackPosition = attackPosition;
				var heading = attackPosition - shotTransform.position;
				var distance = heading.magnitude;
				var direction = heading / distance; 
				move.direction = direction.normalized ;
				move.speed = new Vector2( speed, speed );
			}
		}
	}

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}