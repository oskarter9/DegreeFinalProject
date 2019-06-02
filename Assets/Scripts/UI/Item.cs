using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "InventoryItem")]
public class Item : ScriptableObject {

    public Sprite Icon = null;
    public GameObject ObjectToUse;
}
