using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesManager : MonoBehaviour
{
    public static ReferencesManager instance = null;

    public Transform PlayerObjectsContainer;

    [Header("First Puzzle References")]

    public Light[] POneLights;
    public GameObject POneLightSwitch;
    public GameObject POneControllerContainer;
    public GameObject POneGenreCodesPaper;
    public Item POneLighterItem;
    [HideInInspector]
    public LightmapSwitch POneLighmapSwitch;

    [Header("Second Puzzle References")]
    
    public GameObject PTwoControllerContainer;
    public GameObject PTwoMaleWC;
    public GameObject PTwoFemaleWC;

    //PROVISIONAL
    public AudioClip WrongSound;
    public AudioClip CorrectSound;

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

        POneLighmapSwitch = GetComponentInChildren<LightmapSwitch>();
    }
}
