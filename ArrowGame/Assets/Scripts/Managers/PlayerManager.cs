using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	#region Singleton

	public static PlayerManager instance;
	public static GM gameManager;

	private void Awake()
	{
		if (instance != null) return;
		instance = this;
	}

	#endregion

	public float restartDelay = 3f;
	public GameObject player;


	internal void KillPlayer()
	{
		gameManager.RestartLevel();
	}
}
