using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "InventoryItem")]
public class Item : ScriptableObject {

    //new public string Name = "New Item";
    public Sprite Icon = null;
    public GameObject ObjectToUse;
}
