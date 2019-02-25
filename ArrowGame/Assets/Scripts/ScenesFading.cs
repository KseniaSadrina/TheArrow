using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesFading : MonoBehaviour {


	public Animator animator;
	private int levelToLoad;

	void Update () {
		
	}

	public void FadeToNextLevel()
	{
		FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void FadeToLevel(int levelIndx)
	{
		levelToLoad = levelIndx;
		animator.SetTrigger("FadeOut");
	}


	public void OnFadeComplete()
	{
		SceneManager.LoadScene(levelToLoad);
	}
}

