using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthBarScript : MonoBehaviour {

	public GameObject uiPrefab;
	public Transform target;

	float visibleTime = 5;
	float lastTimeVisible;
	Transform ui;
	Image healthSlider;
	Transform cam;


	void OnHealthChanged(int maxHealth, int currentHealth)
	{
		if (ui != null)
		{
			ui.gameObject.SetActive(true);
			lastTimeVisible = Time.time;

			float healthPercent = (float)currentHealth / maxHealth;
			healthSlider.fillAmount = healthPercent;

			if (currentHealth <= 0)
				Destroy(ui.gameObject);
		}
	}

	void Start () {
		cam = Camera.main.transform;

		foreach (var c in FindObjectsOfType<Canvas>())
		{
			if (c.renderMode == RenderMode.WorldSpace)
			{
				ui = Instantiate(uiPrefab, c.transform).transform;
				healthSlider = ui.GetChild(0).GetComponent<Image>();
				ui.gameObject.SetActive(false);
				break;

			}
		}

		GetComponent<CharacterStats>().onHealthChanged += OnHealthChanged;
	}
	
	void LateUpdate () {
		if (ui != null)
		{
			ui.position = target.position;
			ui.forward = -cam.forward;

			if (Time.time - lastTimeVisible > visibleTime)
				ui.gameObject.SetActive(false);
		}
	}
}
