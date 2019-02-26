using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

	public AudioMixer audioMixer;
	bool muted;
	float currentVol;
	float minVol = -80;
	string ParameterName = "Volume";

	private void Start()
	{
		audioMixer.GetFloat(ParameterName, out currentVol);
	}

	public void SetVolume(float volume)
	{
		audioMixer.SetFloat(ParameterName, volume);
		currentVol = volume;
	}

	public void MuteToggle()
	{
		if (muted) audioMixer.SetFloat(ParameterName, currentVol);
		else audioMixer.SetFloat(ParameterName, -80);
	}
}
