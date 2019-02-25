using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	#region Singleton

	public static GM instance;

	private void Awake()
	{
		if (instance != null) return;
		instance = this;
	}

	#endregion

	public GameObject completeLevelUI;
	public ScenesFading ScenesAnimFading;


	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void CompleteLevel()
	{
		completeLevelUI.SetActive(true);
		var currentSceneIndx = SceneManager.GetActiveScene().buildIndex;
		if (SceneManager.sceneCountInBuildSettings > currentSceneIndx + 1)
		{
			ScenesAnimFading.FadeToNextLevel();
		}
	}

	
}
