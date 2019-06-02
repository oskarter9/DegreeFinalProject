using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    private float randomNumber;
    private float rotationAmount;
	void Start () {
        randomNumber = Random.Range(20,100f);
	}
	
	// Update is called once per frame
	void Update () {
        rotationAmount += Time.deltaTime * randomNumber;
        transform.rotation = Quaternion.Euler(0, rotationAmount, 0);

    }
}
