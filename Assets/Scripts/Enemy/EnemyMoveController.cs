using UnityEngine;
using System.Collections;

public class EnemyMoveController : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	EnemyHealth health;
	PlayerHealthController playerHealth;
	void Awake() {
		health = GetComponent<EnemyHealth> ();
		player = GameObject.Find ("Player").transform;
		playerHealth = player.GetComponent<PlayerHealthController>();
		nav = GetComponent<NavMeshAgent> ();

	}
	
	void Update() {
		if (player != null && playerHealth.CurrentHealth > 0)
			nav.SetDestination (player.position);
		else
			nav.enabled = false;

	}

}
