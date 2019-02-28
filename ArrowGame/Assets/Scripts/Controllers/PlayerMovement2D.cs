using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : CharacterMovement2D {

	PlayerManager playerManager;
	bool isDead;

	protected new void Start()
	{
		base.Start();
		playerManager = PlayerManager.instance;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (isDead) return;
		if (collision.collider.tag == "Enemy")
		{
			// plays animation of death
			animator.SetTrigger("die");
			playerManager.KillPlayer();
			isDead = true;
		}
	}
}


// TODO: 0. DIALOG!
//       1. Add disappearing coins + coins counter
//       2. add patrol to enemy + add one more enemy
//       3.LOD + RAY rendering + camera switch
//       4. Arrow shooting
//       5. fix lighting between scenes
//       6. Fix volume in the main menu
//       7. Add death menu + pause menu to all places required