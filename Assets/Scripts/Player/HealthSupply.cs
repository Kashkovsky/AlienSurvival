using UnityEngine;
using System.Collections;

public class HealthSupply : MonoBehaviour {
	public int HealthIncrease = 20;

	void Update() {
		transform.Rotate (new Vector3(1f,1f,1f));
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.GetComponent<PlayerHealth>().Heal(HealthIncrease);
			Destroy(gameObject);
		}
	}
}
