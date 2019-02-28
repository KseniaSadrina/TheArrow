using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2D: MonoBehaviour {

	public CharacterController2D controller;

	public Animator animator;
	float horizontalMove = 0f;
	bool jump = false;
	public float runSpeed = 40f;

	private void Start()
	{
		animator = GetComponentInChildren<Animator>();
	}

	void Update () {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("speedPercent", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
			jump = true;
	}
	
	void FixedUpdate () {
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
}
