using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchPOne : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            GetComponentInParent<PuzzleOneController>().puzzleSolved = true;
            Destroy(GetComponent<BoxCollider>());
        }
    }
}
