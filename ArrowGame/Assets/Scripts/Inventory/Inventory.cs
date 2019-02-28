using System;
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
		DontDestroyOnLoad(this);
	}

	#endregion

	public int space = 10; 
	public List<Item> items = new List<Item>();
	
	public event Action<Item> onItemChangedCallback;


	public bool Add(Item item)
	{
		if (!item.isDefaultItem)
		{


			if (items.Count >= space && item.name != "Coin")
			{
				//Debug.Log("Can't store more items in the inventory");
				return false ;
			}
			if (item.name != "Coin")
			{
				items.Add(item);
			}

			NotifySubscribers(item);
		}

		return true;
	}

	public void Remove(Item item)
	{
		items.Remove(item);
		NotifySubscribers(item);
	}

	public void NotifySubscribers(Item item)
	{
		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke(item);
	}
}
