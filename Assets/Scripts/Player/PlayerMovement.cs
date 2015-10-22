using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float JumpPower = 6f;
	public float RunSpeed = 2f;

	Rigidbody rb;
	Animator anim;
	Transform cam;
	AudioController audioController; //Later

	Vector3 Move;
	bool Jump;
	float GroundCheckDistance = 0.1f;
	bool  IsGrounded;
	float moveDirection = 1;
	bool jump;

	PlayerShooting gun;
	

	void Awake()
	{

		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		audioController = GetComponent<AudioController> ();
		rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		cam = Camera.main.transform;
		gun = transform.GetComponentInChildren<PlayerShooting> ();
	}
	
	void Update() {
		jump = Input.GetButtonDown ("Jump");

		if (Input.GetButtonDown ("Fire1")) {
			anim.SetBool ("isShooting", true);
		}
		if (Input.GetButtonUp ("Fire1"))
			anim.SetBool ("isShooting", false);
	}

	public void HandleShoot() {
		gun.Shoot ();
	}
	void FixedUpdate ()
	{
		float h = Input.GetAxisRaw("Horizontal");
		moveDirection = h != 0 ? h : moveDirection;
		transform.forward = new Vector3(moveDirection, 0f, 0f);
		Move =  h * cam.right;
		anim.SetFloat ("Walking", h);
		Movement (Move);
		audioController.MovementAudio (h, jump);
	}
	
	void Movement(Vector3 move) {

		move = transform.InverseTransformDirection (move);
		CheckGroundStatus ();
		transform.Translate (move * RunSpeed * Time.deltaTime);
		if (IsGrounded) {
			if (jump) {
				HandleJump ();
			}
		}
	}

	
	void HandleJump() {
		rb.velocity = new Vector3(rb.velocity.x, JumpPower, rb.velocity.z);
		anim.applyRootMotion = false;
	}
	
	void CheckGroundStatus()
	{
		RaycastHit hitInfo;
		Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * GroundCheckDistance));
		if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, GroundCheckDistance))
		{
			IsGrounded = true;
			anim.applyRootMotion = true;
		}
		else
		{
			IsGrounded = false;
			anim.applyRootMotion = false;
		}
	}

}
