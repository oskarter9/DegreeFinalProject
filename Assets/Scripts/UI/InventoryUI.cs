using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform ItemsParent;

    private Inventory _inventory;
    private InventorySlot[] _slots;

    // Use this for initialization
    void Start()
    {
        _inventory = Inventory.instance;
        _inventory.OnItemChangedCallback += UpdateUI;

        _slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < _slots.Length; i++)
        {
            if (i < _inventory.Items.Count)
            {
                _slots[i].AddItem(_inventory.Items[i]);
            }
            else
            {
                _slots[i].ClearSlot();
            }
        }
    }
}
