using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

	// Use this for initialization
	Camera cam;PlayerMotor motor;
	public Interactable focusedItem;
	public LayerMask movementMask;
	

	void Start()
	{
		cam = Camera.main;
		motor = GetComponent<PlayerMotor>();

	}

	// Update is called once per frame
	void Update()
	{
		if (EventSystem.current.IsPointerOverGameObject())
			return;

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100, movementMask))
			{
				motor.MoveToPoint(hit.point);
				RemoveFocus(); // Stop focusing objects
			}
		}

		if (Input.GetMouseButtonDown(1))
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
	}

	private void RemoveFocus()
	{
		if (focusedItem != null)
			focusedItem.OnDefocused();

		focusedItem = null;
		motor.StopFollowTarget();
	}

	private void SetFocus(Interactable newItem)
	{
		if (newItem != focusedItem)
		{
			if(focusedItem != null)
				focusedItem.OnDefocused();

			focusedItem = newItem;
			focusedItem.OnFocused(transform);
		}

		motor.FollowTarget(newItem);
	}
}
