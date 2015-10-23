using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public int DamagePerShot = 20;
	public float TimeBetweenBullets = 0.15f;
	public float Range = 100f;
	
	float timer;
	Ray shootRay;
	RaycastHit shootHit;
	int shootableMask;
	ParticleSystem gunParticles;
	LineRenderer line;
	AudioSource gunAudio;
	Light gunLight;
	float effectsDisplayTime = 0.2f;
	
	void Awake() {
		shootableMask = LayerMask.GetMask ("Shootable");
		gunParticles = GetComponent<ParticleSystem> ();
		line = GetComponent<LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
	}

	public void DisableEffects() {
		line.enabled = false;
		gunLight.enabled = false;
	}
	
	public void Shoot() {
		timer = 0f;
		gunAudio.Play ();
		gunLight.enabled = true;
		gunParticles.Stop ();
		gunParticles.Play ();
		line.enabled = true;
		line.SetPosition (0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;
		
		if (Physics.Raycast (shootRay, out shootHit, Range, shootableMask)) {
			EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth> ();
			if (enemyHealth != null)
				enemyHealth.TakeDamage (DamagePerShot, shootHit.point);
			line.SetPosition (1, shootHit.point);
			Debug.Log (shootHit.point);
		} else
			line.SetPosition (1, shootRay.origin + shootRay.direction * Range);
	}
}
