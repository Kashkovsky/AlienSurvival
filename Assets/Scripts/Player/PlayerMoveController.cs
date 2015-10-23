﻿using UnityEngine;
using System.Collections;

public class PlayerMoveController : MonoBehaviour {

	public float JumpPower = 6f;
	public float RunSpeed = 2f;
	
	Rigidbody rb;
	Animator anim;
	Transform cam;
	
	
	Vector3 Move;
	bool Jump;
	
	float horizontal;
	float moveDirection = 1;
	bool jump;
	
	PlayerShooting gun;
	
	
	void Awake()
	{
		
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		cam = Camera.main.transform;
		gun = transform.GetComponentInChildren<PlayerShooting> ();
	}
	
	void Update() {
		horizontal = Input.GetAxisRaw("Horizontal");
		jump = Input.GetButtonDown ("Jump");
		
	}
	
	
	void FixedUpdate ()
	{
		moveDirection = horizontal != 0 ? horizontal : moveDirection;
		transform.forward = new Vector3(moveDirection, 0f, 0f);
		Move =  horizontal * cam.right;
		anim.SetFloat ("Walk", horizontal);
		Movement (Move);
	}
	
	void Movement(Vector3 move) {
		
		move = transform.InverseTransformDirection (move);
		transform.Translate (move * RunSpeed * Time.deltaTime);
			if (jump) {
				HandleJump ();
			}
	}
	
	
	void HandleJump() {
		rb.velocity = new Vector3(rb.velocity.x, JumpPower, rb.velocity.z);
		anim.applyRootMotion = false;
	}
}
