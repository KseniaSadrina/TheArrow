using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour {

	public CharacterController2D controller;
	float horizontalMove = 0f;
	bool jump = false;
	public float runSpeed = 40f;
	// Use this for initialization
	void Update () {
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			Debug.Log("Jumping " + jump);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}
}
