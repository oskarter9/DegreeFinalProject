using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour {

    public static SoundsManager instance = null;

    public AudioSource SFXSource;

    public AudioClip WrongSound;
    public AudioClip CorrectSound;
    public AudioClip ToiletFlush;

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

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.clip = clip;
        SFXSource.Play();
    }
}
