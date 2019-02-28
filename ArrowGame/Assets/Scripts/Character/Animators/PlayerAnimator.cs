using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimator {

	void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if (newItem != null && newItem.equipmentSlot == EquipmentSlot.Weapon)
		{
			animator.SetLayerWeight(1, 1);
		}
		else if (newItem != null && oldItem != null && oldItem.equipmentSlot == EquipmentSlot.Weapon)
		{
			animator.SetLayerWeight(1,0);
		}
	}

	protected override void Start () {
		base.Start();
		EquipmentManager.instance.onEquipmentChangedCallback += OnEquipmentChanged;
	}
	
	protected override void Update () {
		base.Update();
	}
}
