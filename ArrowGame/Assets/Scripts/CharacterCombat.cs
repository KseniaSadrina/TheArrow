using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

	public float attackSpeed = 1f;
	public float attackDelay = 1f;
	public event System.Action OnAttack;
	public bool InCombat { get; private set; }
	public bool IsFiring { get; private set; }

	CharacterStats myStats;
	float lastAttackTime;
	float lastRangeFireTime;
	const float combatCooldown = 5f;
	private float attackCoolDown = 0f;
	private float fireCooldown = 2f;

	private void Start()
	{
		myStats = GetComponent<CharacterStats>();
	}

	private void Update()
	{
		attackCoolDown -= Time.deltaTime;

		if (Time.time - lastAttackTime > combatCooldown)
			InCombat = false;

		if (Time.time - lastRangeFireTime > fireCooldown)
			IsFiring = false;

		//// when you want to fire some arrows
		//if (Input.GetButtonDown("Fire1"))
		//{
		//	IsFiring = true;
		//	fireCooldown = Time.time;

		//}

	}

	public void Attack(CharacterStats attackedCharacter)
	{
		if (attackCoolDown <= 0f)
		{
			StartCoroutine(DoDamage(attackedCharacter, attackDelay));

			if (OnAttack != null)
				OnAttack();

			attackCoolDown = 1f / attackSpeed;
			InCombat = true;
			lastAttackTime = Time.time;
		}
	}

	IEnumerator DoDamage(CharacterStats stats, float delay)
	{
		yield return new WaitForSeconds(delay);
		stats.TakeDemage(myStats.damage.GetVal());
		if (stats.currentHealth <= 0)
			InCombat = false;

	}
}
