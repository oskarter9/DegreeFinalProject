using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public List<Item> Items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;

    public int space = 6;

    public void Add(Item item)
    {
        Items.Add(item);
        Instantiate(item.ObjectToUse, ReferencesManager.instance.PlayerObjectsContainer.transform);
        ReferencesManager.instance.PlayerObjectsContainer.GetComponent<ObjectSwitching>().SelectObject();

        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
    }

    public void Remove(Item item)
    {
        Items.Remove(item);

        if (OnItemChangedCallback != null)
        {
            OnItemChangedCallback.Invoke();
        }
    }
}
