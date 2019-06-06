using AuraAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumetricLightActivator : MonoBehaviour {

    private Animator _animatorController;

	// Use this for initialization
	void Start () {
        GetComponent<AuraLight>().enabled = true;
        //GetComponent<Light>().cullingMask
        _animatorController = GetComponent<Animator>();
        StartCoroutine(CarPass());
    }

    IEnumerator CarPass()
    {
        yield return new WaitForSeconds(Random.Range(5, 10));
        _animatorController.SetTrigger("CarPass");
        StartCoroutine(CarPass());
    }
}
