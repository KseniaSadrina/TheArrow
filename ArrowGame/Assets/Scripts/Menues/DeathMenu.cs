using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour {

	public static bool isDead = false;
	public GameObject deathhMenuUI;
	public PlayerManager playerManager;

	private void Start()
	{
		playerManager = PlayerManager.instance;
		if (playerManager != null)
			playerManager.onPlayerDied += OpenMenu;
	}

	public void OpenMenu()
	{
		deathhMenuUI.SetActive(true);
		Time.timeScale = 1f;
	}
}
