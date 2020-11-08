﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // List of items that player has ( what player actually has on inventory )
    public List<ScriptableItem> Bag { get; set; }

    // List of items in player's inventory
    public Item_InventorySlot[] InventorySlot { get; private set; }

    private void Awake()
    {
        // Creates a list with 8 slots
        Bag = new List<ScriptableItem>(new ScriptableItem[8]);
        InventorySlot = new Item_InventorySlot[8];

        // GetComponentInChildren<Transform>() is the "Grid" child
        // Fills every InventorySlot index with Item_InventorySlot in children
        InventorySlot = GetComponentInChildren<Transform>().
                        GetComponentsInChildren<Item_InventorySlot>();
    }


    private void Update()
    {
        // Sorts and reverses the list to eliminate free spaces at the beggining
        Bag.Sort();
        Bag.Reverse();

        // Sets the UI items equal to bag items
        for (int i = 0; i < InventorySlot.Length; i++)
        {
            InventorySlot[i].Info = Bag[i];
        }
    }
}
