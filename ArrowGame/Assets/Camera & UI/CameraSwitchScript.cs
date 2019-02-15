using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitchScript : MonoBehaviour {

	[SerializeField] Camera camera1;
	[SerializeField] Camera camera2;


	private void Awake()
	{
		camera1.enabled = true;
		camera2.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.C))
			SwitchCam();

	}

	public void SwitchCam()
	{
		camera1.enabled = !camera1.enabled;
		camera2.enabled = !camera2.enabled;
	}
}
