using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighterBehaviour : MonoBehaviour {

    private Light _lighterLight;
    private bool _lighterOn = false;
    private ParticleSystem _flame;

    // Use this for initialization
    void Start () {
        _lighterLight = GetComponentInChildren<Light>();
        _flame = GetComponentInChildren<ParticleSystem>();
        _flame.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_lighterOn)
            {
                _lighterOn = true;
                _lighterLight.intensity = 1f;
                _flame.Play();
            }
            else
            {
                _lighterOn = false;
                _lighterLight.intensity = 0f;
                _flame.Stop();
            }
        }
    }
}
