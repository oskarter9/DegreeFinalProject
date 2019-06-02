using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberpunkDoor : MonoBehaviour {

    private Animator _doorAnimator;
    private AudioSource _doorAudioSource;

	// Use this for initialization
	void Start () {
        _doorAnimator = GetComponentInChildren<Animator>();
        _doorAudioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _doorAnimator.Play("OpenDoor");
            _doorAudioSource.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _doorAnimator.Play("CloseDoor");
            _doorAudioSource.Play();
        }
    }
}
