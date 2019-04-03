using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluorescentsBehaviour : MonoBehaviour {

    private Animator _fluorescentsAnimator;
    private AudioSource _fluorescentSound;

    void Start()
    {
        _fluorescentsAnimator = GetComponent<Animator>();
        _fluorescentSound = GetComponent<AudioSource>();
    }

    public void EnableFluorescents()
    {
        _fluorescentsAnimator.SetTrigger("TurnOnFluorescents");
        _fluorescentSound.Play();
    }
}
