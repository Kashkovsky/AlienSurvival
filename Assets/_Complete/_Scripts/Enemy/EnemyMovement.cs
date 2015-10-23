using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	EnemyHealth health;
	void Awake() {
		health = GetComponent<EnemyHealth> ();
		player = GameObject.Find ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update() {
		if (health.CurrentHealth <= 0)
			nav.enabled = false;
		if (player != null)
			nav.SetDestination (player.position);
	}
}
