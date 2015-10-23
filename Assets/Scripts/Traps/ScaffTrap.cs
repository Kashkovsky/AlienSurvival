using UnityEngine;
using System.Collections;

public class ScaffTrap : MonoBehaviour {

	public float Force = 10f;
	public int Damage = 5;
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			other.GetComponent<Animator>().applyRootMotion = false;	
			other.GetComponent<PlayerHealthController>().TakeDamage(Damage, transform.position);
			other.GetComponent<Rigidbody>().AddForce(new Vector3(0f, Force, 0f), ForceMode.Impulse);
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.GetComponent<PlayerHealthController>().enabled = true;
		}
	}

}
