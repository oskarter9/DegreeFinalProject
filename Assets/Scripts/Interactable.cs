using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    private bool _isFocused = false;
    private bool _hasInteracted = false;

    public virtual void Interact()
    {
        Debug.Log("INTERACTED");
    }

    public void OnFocused()
    {
        _isFocused = true;
        _hasInteracted = false;
    }

    public void OnDefocused()
    {
        _isFocused = false;
        _hasInteracted = false;
    }

    private void Update()
    {
        if(_isFocused && !_hasInteracted)
        {
            Interact();
            _hasInteracted = true;
        }
    }
}
