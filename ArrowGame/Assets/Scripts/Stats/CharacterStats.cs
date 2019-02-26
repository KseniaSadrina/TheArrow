using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public int maxHealth = 100;
	public int currentHealth { get; private set; }

	public Stat damage;
	public Stat armor;
	public event Action<int, int> onHealthChanged;
	public event Action onDied;

	private void Awake()
	{
		currentHealth = maxHealth;
	}

	public void TakeDemage(int demage)
	{
		demage -= armor.GetVal();
		demage = Mathf.Clamp(demage, 0, int.MaxValue);

		currentHealth -= demage;
		//Debug.Log(transform.name + " takes" + demage + " hit");

		if (onHealthChanged != null)
			onHealthChanged.Invoke(maxHealth, currentHealth);

		if (currentHealth <= 0)
			Die();
	}

	public virtual void Die()
	{
		//Debug.Log(transform.name + " has died :(");
		if (onDied != null)
			onDied.Invoke();
	}

	public void Heal(int healingPts)
	{

		currentHealth += healingPts;
		//Debug.Log(transform.name + " Heals" + healingPts);

		if (onHealthChanged != null)
			onHealthChanged.Invoke(maxHealth, currentHealth);
	}


}
