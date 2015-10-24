using UnityEngine;
using System.Collections;

public class EnemyMovementController : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	
	void Awake() {
		player = GameObject.Find ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
	}

	void Update() {
		if (player != null) {
			nav.SetDestination (player.position);
		} else {
			nav.enabled = false;
		}
	}
}
