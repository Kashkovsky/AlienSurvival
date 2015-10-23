using UnityEngine;
using System.Collections;



public class Punch : MonoBehaviour {

	public float Force = 10f;
	public int Damage = 10;
	private AudioSource source;

	void Awake() {
		source = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			StartCoroutine(PushPlayer(other.gameObject, 2f));
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.GetComponent<PlayerMovement>().enabled = true;
		}
	}

	IEnumerator PushPlayer(GameObject player, float delay) {
		player.GetComponent<PlayerMovement>().enabled = false;
		yield return new WaitForSeconds (delay);
		source.Play ();
		player.GetComponent<Animator>().applyRootMotion = false;
		player.GetComponent<PlayerHealth> ().TakeDamage (Damage, transform.position);
		player.GetComponent<Rigidbody>().AddForce(new Vector3(0f, Force, 0f), ForceMode.Impulse);
	}
}
