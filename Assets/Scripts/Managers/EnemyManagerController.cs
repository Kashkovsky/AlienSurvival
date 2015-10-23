using UnityEngine;
using System.Collections;

public class EnemyManagerController : MonoBehaviour {

	public GameObject Enemy;
	public float SpawnTime = 3f;
	public Transform[] SpawnPoints;
	
	PlayerHealthController playerHealth;

	void Awake() {
		playerHealth = GameObject.Find ("Player").GetComponent<PlayerHealthController> ();
	}
	
	void Start() {

		InvokeRepeating ("Spawn", SpawnTime, SpawnTime);
	}
	
	void Spawn() {
		if (playerHealth.CurrentHealth <= 0)
			return;
		int i = Random.Range (0, SpawnPoints.Length);
		Instantiate (Enemy, SpawnPoints [i].position, SpawnPoints [i].rotation);
	}
}
