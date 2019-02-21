using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : Interactable {

	public Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}

	public override void Interact()
	{
		base.Interact();
		anim.Play("OpenChest");

	}
}
