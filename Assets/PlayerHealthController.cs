using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthController : MonoBehaviour {

	public int StartHealth = 100;
	public int CurrentHealth = 0;
	public Slider HealthSlider;
	public Image DamageImage;
	public float FlashSpeed = 5f;
	public Color FlashColor = new Color (1f, 0f, 0f, 0.1f);
	
	Animator anim;
	PlayerMovement playerMovement;
	ParticleSystem hitParticles;
	
	bool isDead;
	bool damaged;
	
	
	void Awake() {
		anim = GetComponent<Animator> ();
		playerMovement = GetComponent<PlayerMovement> ();
		hitParticles = GetComponentsInChildren<ParticleSystem> ()[0];
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
		if (CurrentHealth <= 0 && !isDead)
			Death ();
	}
	
	void Death ()
	{
		isDead = true;
		anim.SetTrigger ("Die");
		playerMovement.enabled = false;
	}

}
