using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthScript : MonoBehaviour
{
	public ParticleSystem SpecialEffectPrefab;
	public int hp = 1;

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		countScore(damageCount);

		if (hp <= 0)
		{
			destroyDuck ();
			makeEffect(transform.position);
			Destroy(gameObject);
		}
	}

	private ParticleSystem makeEffect(Vector3 position){
		ParticleSystem newParticleSystem = Instantiate(
			SpecialEffectPrefab,
			position,
			Quaternion.identity
		) as ParticleSystem;

		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
		);

		return newParticleSystem;

	}

	public void countScore(int damageCount){
		if (this.transform.parent != null) {
			this.transform.parent.gameObject.GetComponent<TargetSubset> ().targetScore += 1;
		}

	}

	public void destroyDuck(){
		if (this.transform.parent != null) {
			this.transform.parent.gameObject.GetComponent<TargetSubset> ().targetKilled = true;
		}

	}

		
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null) {
			Damage (shot.damage);
			Destroy (shot.gameObject); 
		} 

	}
}