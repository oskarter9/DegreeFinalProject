using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchPOne : MonoBehaviour {

    private Animator _lightBoxAnimator;

    void Awake()
    {
        _lightBoxAnimator = GetComponent<Animator>();
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>() && _lightBoxAnimator.GetBool("OpenDoor"))
        {
            _lightBoxAnimator.SetTrigger("EnablePower");
            GetComponentInParent<PuzzleOneController>().puzzleSolved = true;
        }
        else
        {
            _lightBoxAnimator.SetBool("OpenDoor", true);
        }
    }
}
