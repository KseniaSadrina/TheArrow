using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement2D : CharacterMovement2D {


	[SerializeField] private int nextPosition;
	[SerializeField] private float turnningRadius = 0.03f;
	private Rigidbody2D objRigidBody;
	

	// Patrol positions 

	public Transform[] positions;
	private bool isTurning = false;

	protected new void Start() {
		base.Start();
		objRigidBody = GetComponent<Rigidbody2D>();
		nextPosition = 1;
	}

	void Update()
	{
		if (isTurning) return;
		Patroll();
	}

	private void Patroll()
	{
		ExecuteMovement();

		float distance = Vector2.Distance(positions[nextPosition].transform.position, transform.position);
		if (distance <= turnningRadius)
		{
			isTurning = true;
			nextPosition++;
			if (nextPosition == positions.Length) nextPosition = 0;
			controller.Flip();
			animator.SetTrigger("attack");
		}

	}

	public void OnAttackFinished()
	{
		isTurning = false;
	}

	private void ExecuteMovement()
	{
		animator.SetFloat("speedPercent", runSpeed * Time.deltaTime, controller.m_MovementSmoothing, Time.deltaTime);
		controller.MoveTowards(positions[nextPosition].transform.position, runSpeed);
	}
}
