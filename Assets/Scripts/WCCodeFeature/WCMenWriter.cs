using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCMenWriter : Interactable {

    private List<int> _inputList;

    public override void Interact()
    {
        base.Interact();
        AddMaleCode();
    }

    private void Awake()
    {
        _inputList = GetComponentInParent<WCCodeFeature>().PlayerInput;
    }
    private void AddMaleCode()
    {
        _inputList.Add(0);
    }
}
