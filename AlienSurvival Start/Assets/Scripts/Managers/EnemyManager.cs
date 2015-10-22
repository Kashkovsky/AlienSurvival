using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject Enemy;
	public float SpawnTime = 3f;
	public Transform[] SpawnPoints;

	PlayerHealth playerHealth;
	// Later!
	public static int EnemyStartHealth;
	public static int EnemyDamage;

	void Start() {
		playerHealth = GameObject.Find ("Player").GetComponent<PlayerHealth> ();
		InvokeRepeating ("Spawn", SpawnTime, SpawnTime);

		//Later!
		float difficulty = PlayerPrefsManager.GetDifficulty ();
		if (difficulty == 1) {
			EnemyStartHealth = 10;
			EnemyDamage = 1;
		} else if (difficulty == 2) {
			EnemyStartHealth = 50;
			EnemyDamage = 5;
		} else {
			EnemyStartHealth = 100;
			EnemyDamage = 10;
		}
	}

	void Spawn() {
		if (playerHealth.CurrentHealth <= 0)
			return;
		int i = Random.Range (0, SpawnPoints.Length);
		Instantiate (Enemy, SpawnPoints [i].position, SpawnPoints [i].rotation);
	}
}
