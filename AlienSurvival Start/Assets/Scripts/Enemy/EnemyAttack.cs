using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float TimeBetweenAttacks = 100f;
	public int AttackDamage = 10;
	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	EnemyHealth health;
	bool playerInRange;

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
		if (playerInRange && health.CurrentHealth > 0)
			StartCoroutine ("Attack");
		if (playerHealth.CurrentHealth <= 0) anim.SetTrigger("PlayerDeath");
	}

	IEnumerator Attack() {
		if (playerHealth.CurrentHealth > 0) {
			playerHealth.TakeDamage (AttackDamage, transform.position);
			anim.SetTrigger("Attack");
			Debug.Log("hti");
		}
		yield return new WaitForSeconds(TimeBetweenAttacks);
	}
}
