using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
//	public int StartHealth = 100;
	public int GiveScore = 10;
	public int StartHealth;
	public int CurrentHealth;
	public AudioClip DeathAudio;


	Animator anim;
	AudioSource enemyAudio;
	ParticleSystem hitParticles;
	ParticleSystem deathParticles;
	ParticleSystem smellParticles;
	CapsuleCollider capsuleCollider;
	Score score;

	bool isDead;

	void Awake() {
		anim = GetComponent<Animator> ();
		enemyAudio = GetComponent<AudioSource> ();
		var particles = GetComponentsInChildren<ParticleSystem> ();
		hitParticles = particles[0];
		deathParticles = particles [1];
		smellParticles = particles [2];
		capsuleCollider = GetComponent<CapsuleCollider> ();
		score = GameObject.Find ("ScoreKeeper").GetComponent<Score>();
	}

	void Start() {
		//Later!
		StartHealth = EnemyManager.EnemyStartHealth;
		//To Awake
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
		capsuleCollider.isTrigger = true;
		anim.SetTrigger ("Dead");
		enemyAudio.clip = DeathAudio;
		enemyAudio.Play ();
		score.Add(GiveScore);
		Destroy (gameObject, 7f);
	}	
}
