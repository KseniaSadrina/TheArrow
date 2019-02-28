using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	public Image icon;
	public Button removeButton;
	public Button useButton;

	Item item;
	private bool is2D;

	private void Start()
	{
		is2D = GM.instance.is2D;
	}

	public void AddItem(Item newItem)
	{
		item = newItem;
		icon.sprite = item.icon;
		icon.enabled = true;

		// if this is a coin or a 2D game, disable usage
		if (is2D && useButton != null)
		{
			useButton.interactable = false;
			return;
		}
		removeButton.interactable = true;
	}

	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;

		removeButton.interactable = false;
	}

	public void OnRemoveButton()
	{
		Inventory.instance.Remove(item);
	}

	public void UseItem()
	{
		if (item != null)
		{
			item.Use();
		}
	}
}
