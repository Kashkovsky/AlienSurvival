using UnityEngine;
using System.Collections;

public class FinishScript : MonoBehaviour {

	LevelManager manager;

	void Awake() {
		manager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			manager.LoadNextLevel();
		}
	}
}
