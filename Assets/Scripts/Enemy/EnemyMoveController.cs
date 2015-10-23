using UnityEngine;
using System.Collections;

public class EnemyMoveController : MonoBehaviour {

	Transform player;
	NavMeshAgent nav;
	EnemyHealth health;
	void Awake() {
		health = GetComponent<EnemyHealth> ();
		player = GameObject.Find ("Player").transform;
		nav = GetComponent<NavMeshAgent> ();
	}
	
	void Update() {
		if (player != null)
			nav.SetDestination (player.position);
	}

}
