﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;

	Transform target;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		target = PlayerManager.instance.player.transform;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(target.position, transform.position);
		if (distance <= lookRadius)
		{
			agent.SetDestination(target.position);

			if (distance <= agent.stoppingDistance)
			{
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
}