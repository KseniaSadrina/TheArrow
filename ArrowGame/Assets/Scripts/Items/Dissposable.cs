using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Disposable", menuName = "Inventory/Disposable")]
public class Disposable : Item {

	public int healingPoints;

	public override void Use()
	{
		base.Use();
		var playerStats = PlayerManager.instance.player.GetComponent<PlayerStats>();
		if (playerStats != null)
			playerStats.Heal(healingPoints);
		RemoveFromInventory();


	}
}
