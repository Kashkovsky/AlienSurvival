using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public float RestartDelay = 5f;

	PlayerHealth playerHealth;
	Animator anim;
	float restartTimer;

	void Awake() {
		playerHealth = GameObject.Find ("Player").GetComponent<PlayerHealth> ();
		anim = GetComponent<Animator> ();
	}

	void Update() {
		if (playerHealth.CurrentHealth <= 0) {
			anim.SetTrigger("GameOver");
			restartTimer += Time.deltaTime;
			if (restartTimer >= RestartDelay) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}

}
