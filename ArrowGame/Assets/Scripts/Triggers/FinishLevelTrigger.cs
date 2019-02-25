using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevelTrigger : MonoBehaviour {
	
	GM gameManager;
	bool isLevelComplete = false;

	private void Start()
	{
		gameManager = GM.instance;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (isLevelComplete) return;
		if (other.tag == "Player")
		{
			gameManager.CompleteLevel();
			isLevelComplete = true;
		}
	}

}
