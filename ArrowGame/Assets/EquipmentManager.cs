using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

	#region Singleton

	public static EquipmentManager instance;

	private void Awake()
	{
		if (instance != null)
			return;

		instance = this;

	}

	#endregion

	Equipment[] currentEquipment;
	Inventory inventory;

	public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
	public OnEquipmentChanged onEquipmentChangedCallback;


	private void Start()
	{
		inventory = Inventory.instance;
		var numOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[numOfSlots];
	}

	public void Equip(Equipment newItem)
	{
		var slotIndex = (int)newItem.equipmentSlot;
		Equipment oldItem = null;

		if (currentEquipment[slotIndex] != null)
		{
			oldItem = currentEquipment[slotIndex];
			inventory.Add(oldItem);
		}

		if (onEquipmentChangedCallback != null)
			onEquipmentChangedCallback.Invoke(newItem, oldItem);

		currentEquipment[slotIndex] = newItem;
	}

	public void Unequip(int slotIndex)
	{
		if (currentEquipment[slotIndex] != null)
		{
			var oldItem = currentEquipment[slotIndex];
			inventory.Add(oldItem);

			currentEquipment[slotIndex] = null;


			if (onEquipmentChangedCallback != null)
				onEquipmentChangedCallback.Invoke(null, oldItem);
		}
	}

	public void UnequipAll()
	{
		for (var i = 0; i < currentEquipment.Length; i++)
			Unequip(i);

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.U))
			UnequipAll();
	}

}
