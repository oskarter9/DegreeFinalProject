using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCWomenWriter : Interactable {

    private List<int> _inputList;

    public override void Interact()
    {
        base.Interact();
        AddFemaleCode();
    }

    private void Awake()
    {
        _inputList = GetComponentInParent<WCCodeFeature>().PlayerInput;
    }

    private void AddFemaleCode()
    {
        _inputList.Add(1);
    }
}
