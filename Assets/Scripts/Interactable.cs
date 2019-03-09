using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    private float radius = 2f;
    private bool _isFocused = false;
    private Transform _player;
    private bool _hasInteracted = false;

    public virtual void Interact()
    {
        Debug.Log("INTERACTED");
    }

    public void OnFocused(Transform playerTransform)
    {
        _isFocused = true;
        _player = playerTransform;
        _hasInteracted = false;
    }

    public void OnDefocused()
    {
        _isFocused = false;
        _player = null;
        _hasInteracted = false;
    }

    private void Update()
    {
        if(_isFocused && !_hasInteracted)
        {
            float distance = Vector3.Distance(_player.position, transform.position);
            if(distance <= radius)
            {
                Interact();
                _hasInteracted = true;
            }
        }
    }
}
