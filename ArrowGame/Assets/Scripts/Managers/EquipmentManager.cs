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
	SkinnedMeshRenderer[] currentMashes;
	Inventory inventory;

	public Equipment[] defaultEquipment;
	public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
	public OnEquipmentChanged onEquipmentChangedCallback;
	public SkinnedMeshRenderer targetMesh;

	private void Start()
	{
		inventory = Inventory.instance;
		var numOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[numOfSlots];
		currentMashes = new SkinnedMeshRenderer[numOfSlots];

		EquipDefaultItems();
	}

	public void Equip(Equipment newItem)
	{
		var slotIndex = (int)newItem.equipmentSlot;
		var oldItem = Unequip(slotIndex);
		
		// notify observers
		if (onEquipmentChangedCallback != null)
			onEquipmentChangedCallback.Invoke(newItem, oldItem);

		currentEquipment[slotIndex] = newItem;

		// use the items mashes

		var newMesh = Instantiate(newItem.mesh);
		newMesh.transform.parent = targetMesh.transform;

		newMesh.bones = targetMesh.bones;
		newMesh.rootBone = targetMesh.rootBone;
		currentMashes[slotIndex] = newMesh;
		SetEquipmentBlendShapes(newItem, 100);
	}

	public Equipment Unequip(int slotIndex)
	{
		if (currentEquipment[slotIndex] != null)
		{

			if (currentMashes[slotIndex] != null)
				Destroy(currentMashes[slotIndex].gameObject);
			var oldItem = currentEquipment[slotIndex];
			SetEquipmentBlendShapes(oldItem, 0);
			inventory.Add(oldItem);

			currentEquipment[slotIndex] = null;


			if (onEquipmentChangedCallback != null)
				onEquipmentChangedCallback.Invoke(null, oldItem);

			return oldItem;
		}

		return null;
	}

	public void UnequipAll()
	{
		for (var i = 0; i < currentEquipment.Length; i++)
			Unequip(i);

		EquipDefaultItems();
	}

	void SetEquipmentBlendShapes(Equipment item, int weight)
	{
		if (item == null) return;
		foreach (var meshRegion in item.coveredMeshRegions)
		{
			targetMesh.SetBlendShapeWeight((int)meshRegion, (float)weight);
		}
	}

	void EquipDefaultItems()
	{
		// dress the player with it's default cloths
		foreach (var defaultItem in defaultEquipment)
			Equip(defaultItem);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.U))
			UnequipAll();
	}

}
