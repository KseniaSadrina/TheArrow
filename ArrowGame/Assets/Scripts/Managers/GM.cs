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
	private bool isCoroutineExecuting;

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void CompleteLevel()
	{
		completeLevelUI.SetActive(true);
		var currentSceneIndx = SceneManager.GetActiveScene().buildIndex;
		if (SceneManager.sceneCountInBuildSettings > currentSceneIndx + 1)
			StartCoroutine(ExecuteAfterTime(3f, () => ScenesAnimFading.FadeToNextLevel()));
	}

	IEnumerator ExecuteAfterTime(float time, Action task)
	{
		if (isCoroutineExecuting)
			yield break;
		isCoroutineExecuting = true;
		yield return new WaitForSeconds(time);
		task();
		isCoroutineExecuting = false;
	}

	public void PlayAgain()
	{
		SceneManager.LoadScene(1);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
