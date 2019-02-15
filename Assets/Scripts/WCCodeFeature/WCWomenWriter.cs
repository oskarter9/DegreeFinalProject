using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCWomenWriter : MonoBehaviour {

    private List<int> _inputList;
    private bool _insideArea = false;

    private void Awake()
    {
        _inputList = GetComponentInParent<WCCodeFeature>().PlayerInput;
    }

    private void Update()
    {
        if(_insideArea && Input.GetKeyDown(KeyCode.F))
        {
            _inputList.Add(1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            _insideArea = true;  
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            _insideArea = false;
        }
    }
}
