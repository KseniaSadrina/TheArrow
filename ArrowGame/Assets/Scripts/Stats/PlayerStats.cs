using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

	private void Start()
	{
		EquipmentManager.instance.onEquipmentChangedCallback += OnEquipmentChanged;
	}

	private void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if (newItem != null)
		{
			armor.AddMofifier(newItem.armorModifier);
			damage.AddMofifier(newItem.damageModifier);
		}

		if (oldItem != null)
		{
			armor.RemoveMofifier(oldItem.armorModifier);
			damage.RemoveMofifier(oldItem.damageModifier);
		}

	}
}
