using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : CharacterController2D {

	// Use this for initialization
	Camera cam;
	public Interactable focusedItem;
	

	void Start()
	{
		cam = Camera.main;

	}

	// Update is called once per frame
	void Update()
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 100))
		{
			Interactable interactable = hit.collider.GetComponent<Interactable>();
			if (interactable != null)
				SetFocus(interactable);
		}
	}

	private void RemoveFocus()
	{
		if (focusedItem != null)
			focusedItem.OnDefocused();

		focusedItem = null;
	}

	private void SetFocus(Interactable newItem)
	{
		if (newItem != focusedItem)
		{
			if (focusedItem != null)
				focusedItem.OnDefocused();

			focusedItem = newItem;
		}

		focusedItem.OnFocused(transform);
	}
}
