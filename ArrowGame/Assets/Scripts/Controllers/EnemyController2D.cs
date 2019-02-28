using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2D : CharacterController2D {

	public float lookRadius = 4f;

	Transform target;
	bool inCombat = false;
	CharacterCombat combat;
	CharacterMovement2D movements;
	int nextPosition;
	Rigidbody2D objRigidBody;
	// Patrol positions 

	public Transform[] positions;
	public bool isPatrolling;

	void Start()
	{
		target = PlayerManager.instance.player.transform;
		combat = GetComponent<CharacterCombat>();
		objRigidBody = GetComponent<Rigidbody2D>();
		movements = GetComponent<CharacterMovement2D>();
	}

	void Update()
	{
		float distance = Vector3.Distance(target.position, transform.position);
		if (distance <= lookRadius)
		{
			//agent.SetDestination(target.position);

			//if (distance <= agent.stoppingDistance)
			//{
			//	// Interupt the patroll
			//	chasingTarget = true;

			//	// Attack the target
			//	var targetStats = target.GetComponent<CharacterStats>();
			//	if (targetStats != null)
			//		combat.Attack(targetStats);

			//	FaceTarget();
			//}
		}
		if (inCombat) return;
		Patroll();
	}

	private void Patroll()
	{
		if (!isPatrolling) return;
		
		if (transform.position == positions[nextPosition].transform.position) nextPosition++;
		if (nextPosition == positions.Length) nextPosition = 0;

	}

	private void MoveTowards()
	{
		float speedPercent = objRigidBody.velocity.magnitude / movements.runSpeed;
		movements.animator.SetFloat("speedPercent", speedPercent, m_MovementSmoothing, Time.deltaTime);
		transform.position = Vector2.MoveTowards(transform.position, positions[nextPosition].transform.position,
			movements.runSpeed * Time.deltaTime);
	}
}
