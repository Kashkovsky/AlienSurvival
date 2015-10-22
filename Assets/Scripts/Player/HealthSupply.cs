using UnityEngine;
using System.Collections;

public class HealthSupply : MonoBehaviour {
	public int HealthIncrease = 20;

	void Update() {
		transform.Rotate (new Vector3(1f,1f,1f));
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			var health = other.GetComponent<PlayerHealth>();
			if (health.CurrentHealth < health.StartHealth)
			{
				int healAmount = health.CurrentHealth <= health.StartHealth - HealthIncrease 
						? HealthIncrease
						: health.StartHealth - health.CurrentHealth;
				health.Heal(healAmount);
				Destroy(gameObject);
			}
		}
	}

}
