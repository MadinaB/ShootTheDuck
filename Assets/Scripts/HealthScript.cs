using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthScript : MonoBehaviour
{
	public int hp = 1;

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		GameObject.FindGameObjectWithTag("BackgroundTask").GetComponent<GameBackground>().kill = true;

		if (hp <= 0)
		{
			SpecialEffectsHelperScript.Instance.Explosion(transform.position);
			Destroy(gameObject);
		}
	}
		
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null) {
			Damage (shot.damage);
			Destroy (shot.gameObject); 
		} 
		//else {
		//	Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), otherCollider.GetComponent<Collider2D>());
		//}

	}
}