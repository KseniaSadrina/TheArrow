using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterEnemy : Enemy {

	public GameObject[] objectsToEnable;

	protected override void HandleDeath()
	{
		if (objectsToEnable != null)
		{
			foreach (var obj in objectsToEnable)
				if (obj != null) obj.SetActive(true);
		}

		base.HandleDeath();
	}
}
