using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : Interactable {

	Animator anim;
	Collider collider;
	public GameObject itemInsideChest;

	void Start () {
		anim = GetComponent<Animator>();
		collider = GetComponent<Collider>();
	}

	public override void Interact()
	{

		base.Interact();
		anim.Play("OpenChest");
		collider.enabled = false;
		if (itemInsideChest != null)
			itemInsideChest.SetActive(true);
	}
}
