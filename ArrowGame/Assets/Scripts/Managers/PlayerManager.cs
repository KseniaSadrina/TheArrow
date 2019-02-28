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

	public event Action onPlayerDied;
	public float restartDelay = 3f;
	public GameObject player;
	private bool isDead;


	internal void KillPlayer()
	{
		if (isDead) return;
		if (onPlayerDied != null)
		{
			onPlayerDied.Invoke();
			isDead = true;
		}
	}
}
