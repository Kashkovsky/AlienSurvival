using UnityEngine;
using System.Collections;

public class EnemyHealthController : MonoBehaviour {

	public int StartHealth = 100;
	public int CurrentHealth;
	public int GiveScore = 10;
	public AudioClip DeathAudio;
	
	
	Animator anim;
	AudioSource enemyAudio;
	ParticleSystem hitParticles;
	ParticleSystem deathParticles;
	ParticleSystem smellParticles;
	
	bool isDead;
	
	void Awake() {
		anim = GetComponent<Animator> ();
		enemyAudio = GetComponent<AudioSource> ();
		var particles = GetComponentsInChildren<ParticleSystem> ();
		hitParticles = particles[0];
		deathParticles = particles [1];
		smellParticles = particles [2];
	}
	
	void Start() {
		CurrentHealth = StartHealth;
	}
	
	public void TakeDamage(int amount, Vector3 hitPoint) {
		if (isDead)
			return;
		enemyAudio.Play ();
		CurrentHealth -= amount;
		hitParticles.transform.position = hitPoint;
		hitParticles.Play ();
		
		if (CurrentHealth <= 0)
			Death ();
	}
	
	void Death() {
		isDead = true;
		deathParticles.Play ();
		smellParticles.Play ();
		anim.SetTrigger ("Dead");
		enemyAudio.clip = DeathAudio;
		enemyAudio.Play ();
		Destroy (gameObject, 7f);
	}	
}
