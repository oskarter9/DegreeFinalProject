﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public Image Icon;

    private Item _item;

    public void AddItem(Item newItem)
    {
        _item = newItem;

        Icon.sprite = _item.Icon;
        Icon.enabled = true;
    }

    public void ClearSlot()
    {
        _item = null;

        Icon.sprite = null;
        Icon.enabled = false;
    }
}