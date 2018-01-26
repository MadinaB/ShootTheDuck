using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpecialEffectsHelperScript : MonoBehaviour
{
	public static SpecialEffectsHelperScript Instance;

	public ParticleSystem smokeEffect;

	void Awake()
	{
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SpecialEffectsHelper!");
		}

		Instance = this;
	}

	public void Explosion(Vector3 position)
	{
		instantiate(smokeEffect, position);
	}
		
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
		) as ParticleSystem;

		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
		);

		return newParticleSystem;
	}
}