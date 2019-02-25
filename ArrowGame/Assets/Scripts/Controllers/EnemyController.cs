using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;


	Transform target;
	NavMeshAgent agent;
	bool chasingTarget = false;
	CharacterCombat combat;
	// Patrol positions 

	public Transform position1;
	public Transform position2;
	public Transform position3;
	public Transform position4;
	public bool isPatrolling;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		target = PlayerManager.instance.player.transform;
		combat = GetComponent<CharacterCombat>();
	}
	
	void Update () {
		float distance = Vector3.Distance(target.position, transform.position);
		if (distance <= lookRadius)
		{
			agent.SetDestination(target.position);

			if (distance <= agent.stoppingDistance)
			{
				// Interupt the patroll
				chasingTarget = true;
				
				// Attack the target
				var targetStats = target.GetComponent<CharacterStats>();
				if (targetStats != null)
					combat.Attack(targetStats);
				
				FaceTarget();
			}
		}
	}

	private void FaceTarget()
	{
		var direction = (target.position - transform.position).normalized;
		var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
		
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (chasingTarget) return;
		Patroll(collider);
	}

	private void Patroll(Collider collider)
	{
		if (!isPatrolling) return;
		switch (collider.tag)
		{
			case "1":
				agent.SetDestination(position2.position);
				break;
			case "2":
				agent.SetDestination(position3.position);
				break;
			case "3":
				agent.SetDestination(position4.position);
				break;
			case "4":
				agent.SetDestination(position1.position);
				break;
		}
	}
}
