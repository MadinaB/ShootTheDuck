using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

/// <summary>
/// Creating instance of particles from code with no effort
/// </summary>
public class SpecialEffectsHelperScript : MonoBehaviour
{
	/// <summary>
	/// Singleton
	/// </summary>
	public static SpecialEffectsHelperScript Instance;

	public ParticleSystem smokeEffect;

	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SpecialEffectsHelper!");
		}

		Instance = this;
	}

	/// <summary>
	/// Create an explosion at the given location
	/// </summary>
	/// <param name="position"></param>
	public void Explosion(Vector3 position)
	{
		instantiate(smokeEffect, position);
	}

	/// <summary>
	/// Instantiate a Particle system from prefab
	/// </summary>
	/// <param name="prefab"></param>
	/// <returns></returns>
	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(
			prefab,
			position,
			Quaternion.identity
		) as ParticleSystem;

		// Make sure it will be destroyed
		Destroy(
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
		);

		return newParticleSystem;
	}
}