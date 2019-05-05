using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour {

    public static SoundsManager instance = null;

    public AudioSource SFXSource;
    public AudioSource SFXPuzzleTwoSource;

    public AudioSource[] SceneAAudioSourceList;

    public AudioClip CorrectPuzzle;

    public AudioClip WrongSound;
    public AudioClip ToiletFlush;
    public AudioClip NoInteractable;

    public AudioClip TVSynthLoop;

    public AudioClip MorseCodeInput;
    public AudioClip BadCodeInput;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioSource audioSource, AudioClip clip)
    {
        audioSource.volume = 0.2f;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void DisableSceneAAudio()
    {
        foreach (var audioSource in SceneAAudioSourceList)
        {
            audioSource.mute = true;
        }
    }

    public void EnableSceneAAudio()
    {
        foreach (var audioSource in SceneAAudioSourceList)
        {
            audioSource.mute = false;
        }
    }
}
