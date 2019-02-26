using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsManager : MonoBehaviour {

	#region Singleton

	private void Awake()
	{
		if (instance != null) return;
		instance = this;
	}

	#endregion

	public Target[] targets;
	public static TargetsManager instance;
	public GameObject[] objectsToEnable;

	int hitCount;
	int total;

	// Use this for initialization
	void Start () {
		if (targets != null)
		{
			total = targets.Length;
			hitCount = 0;
			foreach (var target in targets)
			{
				if (target != null)
				{
					target.onTargetHit += OnTargetHit;
				}
			}
		}
	}

	private void OnTargetHit(Target target)
	{
		if (target != null)
		{
			++hitCount;
			target.onTargetHit -= OnTargetHit;
		}
	}

	// Update is called once per frame
	void Update () {
		if (total <= hitCount)
			NotifyLevelComplete();
	}

	protected void NotifyLevelComplete()
	{
		if (objectsToEnable != null)
		{
			foreach (var obj in objectsToEnable)
				if (obj != null) obj.SetActive(true);
		}

	}
}
