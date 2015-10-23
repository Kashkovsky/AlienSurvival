using UnityEngine;
using System.Collections;

public class EnemyMoveController : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	EnemyHealthController health;
	PlayerHealthController playerHealth;
	void Awake() {
		health = GetComponent<EnemyHealthController> ();
		player = GameObject.Find ("Player").transform;
		playerHealth = player.GetComponent<PlayerHealthController>();
		nav = GetComponent<NavMeshAgent> ();

	}
	
	void Update() {
		if (health.CurrentHealth <= 0) {
			nav.enabled = false;
		}
		if (player != null && playerHealth.CurrentHealth > 0)
			nav.SetDestination (player.position);
		else
			nav.enabled = false;

	}

}
