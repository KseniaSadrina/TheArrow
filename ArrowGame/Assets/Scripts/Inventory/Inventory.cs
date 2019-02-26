using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	#region Singleton

	public static Inventory instance;

	private void Awake()
	{
		if (instance != null)
		{
			//Debug.LogWarning("More than one instance of inventory");
			return;
		}

		instance = this;
	}

	#endregion

	public int space = 10; 
	public List<Item> items = new List<Item>();

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;


	public bool Add(Item item)
	{
		if (!item.isDefaultItem)
		{
			if (items.Count >= space)
			{
				//Debug.Log("Can't store more items in the inventory");
				return false ;
			}

			items.Add(item);
			NotifySubscribers();
		}

		return true;
	}

	public void Remove(Item item)
	{
		items.Remove(item);
		NotifySubscribers();
	}

	public void NotifySubscribers()
	{
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}
}
