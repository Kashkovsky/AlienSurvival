using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

	public int StartHealth = 100;
	public int CurrentHealth;
	public Slider HealthSlider;
	public Image DamageImage;

	public float FlashSpeed = 5f;
	public Color FlashColor = new Color (1f, 0f, 0f, 0.1f);
	
	Animator anim;
	PlayerMovementController movementController;
	ParticleSystem particles;

	bool isDead;
	bool damaged;

	void Awake() {
		anim = GetComponent<Animator> ();
		movementController = GetComponent<PlayerMovementController> ();
		particles = transform.GetComponentInChildren<ParticleSystem> ();
		CurrentHealth = StartHealth;
	}

	void Update() {
		if (damaged) {
			DamageImage.color = FlashColor;
		} else {
			DamageImage.color = Color.Lerp (DamageImage.color, Color.clear, FlashSpeed * Time.deltaTime);
		}
	}

	public void TakeDamage (int amount, Vector3 hitPoint) {
		damaged = true;
		particles.transform.LookAt (hitPoint);
		particles.Play ();
		CurrentHealth -= amount;
		HealthSlider.value = CurrentHealth;
		if (CurrentHealth <= 0 && !isDead) {
			Death();
		}
	}

	void Death () {
		isDead = true;
		anim.SetTrigger("Death");
		movementController.enabled = false;
	}
}
