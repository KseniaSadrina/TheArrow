using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour {

	const float locomationAnimationSmoothTime = .1f;
	protected Animator animator;
	NavMeshAgent agent;
	protected CharacterCombat combat;

	protected virtual void Start () {
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
		combat = GetComponent<CharacterCombat>();
		combat.OnAttack += OnAttack;
	}
	
	protected virtual void Update () {
		float speedPercent = agent.velocity.magnitude / agent.speed;
		animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);

		animator.SetBool("inCombat", combat.InCombat);
		animator.SetBool("isFiring", combat.IsFiring);
	}

	protected virtual void OnAttack()
	{
		animator.SetTrigger("attack");
	}
}
