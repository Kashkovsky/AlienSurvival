using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

	public float JumpPower = 10f;
	public float Speed = 3f;

	private Rigidbody rb;
	private Animator anim;

	private Vector3 movement;
	private bool jump;
	private float horizontal;
	private float moveDirection = 1f;


	void Awake() {
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();

	}

	void Update () {
		horizontal = Input.GetAxisRaw("Horizontal");
		jump = Input.GetButtonDown("Jump");
	}

	void FixedUpdate() {
		moveDirection = horizontal != 0 ? horizontal : moveDirection;
		transform.forward = new Vector3 (moveDirection, 0f, 0f);
		movement = horizontal * Camera.main.transform.right;
		anim.SetFloat ("Walking", horizontal);
		Move (movement);
	}

	void Move(Vector3 move) {
		move = transform.InverseTransformDirection (move);
		transform.Translate (move * Speed * Time.deltaTime);
		if (jump) {
			HandleJump();
		}
	}

	void HandleJump () {
		rb.velocity = new Vector3 (rb.velocity.x, JumpPower, rb.velocity.z);
	}
}
