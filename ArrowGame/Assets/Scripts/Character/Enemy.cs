using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable {

	PlayerManager playerManager;
	protected CharacterStats myStats;
	

	protected void Start()
	{
		playerManager = PlayerManager.instance;
		myStats = GetComponent<CharacterStats>();

		if (myStats != null)
			myStats.onDied += OnEnemyDied;
	}
	

	public override void Interact()
	{
		base.Interact();
		var playerCombat = playerManager.player.GetComponent<CharacterCombat>();
		if (playerCombat != null && myStats != null)
		{
			playerCombat.Attack(myStats);
		}
	}

	private void OnEnemyDied()
	{
		HandleDeath();
	}

	protected virtual void HandleDeath()
	{
		if (myStats != null) myStats.onDied -= OnEnemyDied;
		Destroy(gameObject);
	}
}
