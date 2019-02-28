using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements2D : MonoBehaviour {


	public CharacterController2D controller;

	Animator animator;
	float horizontalMove = 0f;
	public float runSpeed = 40f;
	private bool jump;

	private void Start()
	{
		animator = GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController2D>();
	}

	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("speedPercent", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
			jump = true;

	}

	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}
}
