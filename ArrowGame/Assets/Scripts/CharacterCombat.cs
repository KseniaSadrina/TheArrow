using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

	public float attackSpeed = 1f;
	public float attackDelay = 1f;
	public event System.Action OnAttack;

	CharacterStats myStats;
	private float attackCoolDown = 0f;

	private void Start()
	{
		myStats = GetComponent<CharacterStats>();
	}

	private void Update()
	{
		attackCoolDown -= Time.deltaTime;
	}

	public void Attack(CharacterStats attackedCharacter)
	{
		if (attackCoolDown <= 0f)
		{
			StartCoroutine(DoDamage(attackedCharacter, attackDelay));

			if (OnAttack != null)
				OnAttack();

			attackCoolDown = 1f / attackSpeed;

		}
	}

	IEnumerator DoDamage(CharacterStats stats, float delay)
	{
		yield return new WaitForSeconds(delay);
		stats.TakeDemage(myStats.damage.GetVal());

	}
}
