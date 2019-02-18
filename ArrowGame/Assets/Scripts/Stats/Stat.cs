using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat  {

	[SerializeField]
	private int baseValue;

	private List<int> modifiers = new List<int>();

	public int GetVal()
	{
		var finalValue = baseValue;
		modifiers.ForEach(modifier => finalValue += modifier);
		return finalValue;
	}


	public void AddMofifier(int modifier)
	{
		if (modifier != 0)
			modifiers.Add(modifier);

	}

	public void RemoveMofifier(int modifier)
	{
		if (modifier != 0)
			modifiers.Remove(modifier);

	}
}
