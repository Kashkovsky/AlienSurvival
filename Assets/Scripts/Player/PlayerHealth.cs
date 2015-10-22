using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int StartHealth = 100;
	public int CurrentHealth = 0;
	public Slider HealthSlider;
	public Image DamageImage;
	public float FlashSpeed = 5f;
	public Color FlashColor = new Color (1f, 0f, 0f, 0.1f);

	Animator anim;
	AudioController audioController;
	PlayerMovement playerMovement;
	ParticleSystem hitParticles;
	Score score;
	bool isDead;
	bool damaged;

	void Awake() {
		anim = GetComponent<Animator> ();
		audioController = GetComponent<AudioController> ();
		playerMovement = GetComponent<PlayerMovement> ();
		hitParticles = GetComponentsInChildren<ParticleSystem> ()[0];
		score = GameObject.Find ("ScoreKeeper").GetComponent<Score>();
		CurrentHealth = StartHealth;
	}

	void Update() {
		if (damaged)
			DamageImage.color = FlashColor;
		else
			DamageImage.color = Color.Lerp (DamageImage.color, Color.clear, FlashSpeed * Time.deltaTime);
		damaged = false;	
	}

	public void TakeDamage(int amount, Vector3 hitPoint) {
		damaged = true;
		hitParticles.transform.LookAt(hitPoint);
		hitParticles.Play ();
		CurrentHealth -= amount;
		HealthSlider.value = CurrentHealth;
		audioController.HealthAudio (false);
		if (CurrentHealth <= 0 && !isDead)
			Death ();
	}

	void Death ()
	{
		isDead = true;
		anim.SetTrigger ("Die");
		audioController.HealthAudio (true);
		playerMovement.enabled = false;
		score.GameOver ();
	}

	public void Heal(int amount) {
		Debug.Log ("Healed : " + amount);
		CurrentHealth += amount;
		HealthSlider.value = CurrentHealth;
	}
}
