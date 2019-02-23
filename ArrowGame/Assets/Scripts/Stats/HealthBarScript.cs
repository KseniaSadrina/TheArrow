using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthBarScript : MonoBehaviour {

	public GameObject uiPrefab;
	public Transform target;
	float visibleTime = 5;

	Transform ui;
	Image healthSlider;
	Transform cam;

	void Start () {
		cam = Camera.main.transform;

		foreach (var c in FindObjectsOfType<Canvas>())
		{
			if (c.renderMode == RenderMode.WorldSpace)
			{
				ui = Instantiate(uiPrefab, c.transform).transform;
				healthSlider = ui.GetChild(0).GetComponent<Image>();
				break;

			}
		}		
	}
	
	void LateUpdate () {
		ui.position = target.position;
		ui.forward = -cam.forward;
	}
}
