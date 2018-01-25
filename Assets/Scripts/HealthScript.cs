using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthScript : MonoBehaviour
{
	public int hp = 1;

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		countScore (damageCount);

		if (hp <= 0)
		{
			SpecialEffectsHelperScript.Instance.Explosion(transform.position);
			destroyDuck ();
			Destroy(gameObject);
		}
	}

	public void countScore(int damageCount){
		GameBackground bgTask = GameObject.FindGameObjectWithTag ("BackgroundTask").GetComponent<GameBackground> ();
		string duck = gameObject.GetComponent<SpriteRenderer> ().sortingLayerName;

		if (duck == bgTask.bigDuckLayer) {
			GameObject.FindGameObjectWithTag("BackgroundTask").GetComponent<GameBackground>().score += damageCount;
		}
		else if (duck == bgTask.smallDuckLayer) {
			GameObject.FindGameObjectWithTag("BackgroundTask").GetComponent<GameBackground>().score += (damageCount*3);
		}
		else if (duck == bgTask.targetCircleLayer) {
			GameObject.FindGameObjectWithTag("BackgroundTask").GetComponent<GameBackground>().score += (damageCount*2);
		}

	}

	public void destroyDuck(){
		GameBackground bgTask = GameObject.FindGameObjectWithTag ("BackgroundTask").GetComponent<GameBackground> ();
		string duck = gameObject.GetComponent<SpriteRenderer> ().sortingLayerName;

		if (duck == bgTask.bigDuckLayer) {
			GameObject.FindGameObjectWithTag("BackgroundTask").GetComponent<GameBackground>().bigDuckKilled = true;
		}
		else if (duck == bgTask.smallDuckLayer) {
			GameObject.FindGameObjectWithTag("BackgroundTask").GetComponent<GameBackground>().smallDuckKilled = true;
		}
		else if (duck == bgTask.targetCircleLayer) {
			GameObject.FindGameObjectWithTag("BackgroundTask").GetComponent<GameBackground>().targetCircleKilled= true;
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