using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchPOne : Interactable {

    private Animator _lightBoxAnimator;

    public override void Interact()
    {
        base.Interact();
        OpenDoor();

    }

    void Awake()
    {
        _lightBoxAnimator = GetComponent<Animator>();
    }

    void OpenDoor()
    {
        _lightBoxAnimator.SetBool("OpenDoor", true);
    }

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>() && _lightBoxAnimator.GetBool("OpenDoor"))
        {
            _lightBoxAnimator.SetTrigger("EnablePower");
            GetComponentInParent<PuzzleOneController>().powerEnabled = true;
            Destroy(this);
        }
    }
}
