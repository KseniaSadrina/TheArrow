using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	public Transform itemsParent;
	public GameObject inventoryUI;
	[SerializeField] Text CoinsCounter;
	[SerializeField] Text TotalCoins;

	Inventory inventory;
	InventorySlot[] slots;
	const string coin = "Coin";
	int maxCoinsCount = 93;
	int currentCoins = 0;

	void Start () {
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;

		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
		TotalCoins.text = maxCoinsCount.ToString();
		CoinsCounter.text = currentCoins.ToString();
	}
	
	void Update ()
	{
		if (Input.GetButtonDown("Inventory")) {
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
	}
	void UpdateUI(Item item)
	{
		if (item.name == coin)
		{
			currentCoins++;
			CoinsCounter.text = currentCoins.ToString();
		}
		for (var i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count && inventory.items[i].name != coin)
			{
				slots[i].AddItem(inventory.items[i]);
			}
			else
			{
				slots[i].ClearSlot();
			}

		}
		

	}


}
