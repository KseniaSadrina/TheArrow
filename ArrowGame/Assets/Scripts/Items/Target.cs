using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Interactable {


	bool isHit;
	public event Action<Target> onTargetHit; 

	private void OnTriggerEnter(Collider other)
	{
		if (isHit) return;
		if (other.tag == "Arrow" && onTargetHit != null)
		{
			isHit = true;
			onTargetHit.Invoke(this);
		}
	}
}
