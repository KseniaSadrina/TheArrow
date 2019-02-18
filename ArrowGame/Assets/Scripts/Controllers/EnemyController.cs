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
	// Patrol positions 

	public Transform position1;
	public Transform position2;
	public Transform position3;
	public Transform position4;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		target = PlayerManager.instance.player.transform;
	}
	
	void Update () {
		float distance = Vector3.Distance(target.position, transform.position);
		if (distance <= lookRadius)
		{
			agent.SetDestination(target.position);

			if (distance <= agent.stoppingDistance)
			{
				chasingTarget = true;
				// Attack the target
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

	private void OnTriggerEnter(Collider other)
	{
		if (chasingTarget) return;
		switch (other.tag)
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
