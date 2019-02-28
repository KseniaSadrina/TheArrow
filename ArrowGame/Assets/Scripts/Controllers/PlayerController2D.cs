using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : CharacterController2D {
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		var interactable = collision.collider.GetComponent<Interactable>();
		if (interactable != null)
			interactable.Interact();
	}
}
