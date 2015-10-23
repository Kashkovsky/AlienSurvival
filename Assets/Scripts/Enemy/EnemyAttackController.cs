using UnityEngine;
using System.Collections;

public class EnemyAttackController : MonoBehaviour {

	public float TimeBetweenAttacks = 100f;
	public int AttackDamage = 10;
	public AudioClip AttackSound;
	public int AttackMultiplier = 5;

	Animator anim;
	GameObject player;
	AudioSource source;
	PlayerHealthController playerHealth;
	EnemyHealthController enemyHealth;
	bool playerInRange;
	float timer = 0f;
	void Awake() {
		player = GameObject.Find("Player");
		playerHealth = player.GetComponent<PlayerHealthController> ();
		anim = GetComponent<Animator> ();
		source = GetComponent<AudioSource> ();
		enemyHealth = GetComponent<EnemyHealthController> ();
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
		if (playerInRange && timer >= TimeBetweenAttacks && enemyHealth.CurrentHealth > 0)
			Attack ();
		
		if (playerHealth.CurrentHealth <= 0) {
			anim.SetTrigger("PlayerDeath");
		}
	}
	
	void Attack() {
		if (playerHealth.CurrentHealth > 0) {
			source.clip = AttackSound;
			source.Play ();
			playerHealth.TakeDamage (AttackDamage * AttackMultiplier, transform.position);
			anim.SetTrigger("Attack");
			timer = 0f;
		}
	}
}
