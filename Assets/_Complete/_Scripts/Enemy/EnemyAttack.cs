using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float TimeBetweenAttacks = 100f;
	//public int AttackDamage = 10;
	//Later
	int AttackDamage;
	public int AttackMultiplier = 5;
	//
	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth health;
	bool playerInRange;
	float timer = 0f;
	void Awake() {
		player = GameObject.Find("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
		health = GetComponent<EnemyHealth> ();
		anim = GetComponent<Animator> ();
	}

	//Later
	void Start() {
		AttackDamage = EnemyManager.EnemyDamage;
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject == player)
			playerInRange = true;
	} 

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject == player)
			playerInRange = false;
	}

	void Update() {
		timer += Time.deltaTime;
		if (playerInRange && timer >= TimeBetweenAttacks && health.CurrentHealth > 0)
			Attack ();

		if (playerHealth.CurrentHealth <= 0) anim.SetTrigger("PlayerDeath");
	}

	void Attack() {
		if (playerHealth.CurrentHealth > 0) {
			playerHealth.TakeDamage (AttackDamage * AttackMultiplier, transform.position);
			anim.SetTrigger("Attack");
			timer = 0f;
		}
	}
}
