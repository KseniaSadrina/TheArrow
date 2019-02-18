using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item {

	public EquipmentSlot equipmentSlot;
	public int armorModifier;
	public int damageModifier;
	public SkinnedMeshRenderer mesh;
	public EquipmentMeshRegion[] coveredMeshRegions;


	public override void Use()
	{
		base.Use();
		EquipmentManager.instance.Equip(this);
		RemoveFromInventory();
	}
}


public enum EquipmentSlot { Chest, Legs, Weapon, Ammunition, Head, Feet }
public enum EquipmentMeshRegion { Legs, Arms, Torso } // Corresponds to body blend shapes