using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBehaviour : MonoBehaviour {

    public Material _fanEmissive;

    private bool _fanEmissionEnabled;
    private bool _fanRotationEnabled;
    private Transform _fanRotators;

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().Stop();
        _fanEmissive.DisableKeyword("_EMISSION");
        _fanRotators = transform.GetChild(0);
    }
	
	// Update is called once per frame
	void Update () {
        if (_fanRotationEnabled)
        {
            _fanRotators.Rotate(new Vector3(0, 20, 0));
        }
    }

    public void EnableFan()
    {
        _fanEmissive.EnableKeyword("_EMISSION");
        GetComponent<AudioSource>().Play();
        _fanRotationEnabled = true;
    }
}
