using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesManager : MonoBehaviour
{
    public static ReferencesManager instance = null;

    public Transform PlayerObjectsContainer;
    public Player Player;
    public GameObject SoundClueSource;
    public Canvas MainCanvas;
    public DialogueTrigger CurrentStoryDialogue;

    [Header("First Puzzle References")]

    public Light[] POneLights;
    public AudioSource POneTobaccoMachine;
    public GameObject[] POneFans;
    public GameObject POneFluorescentsContainer;
    public GameObject POneMainRoomLightsContainer;
    public GameObject POneLightSwitch;
    public GameObject POneControllerContainer;
    public GameObject POneGenreCodesPaper;
    public Transform POneGenreCodesPaperContainer;
    public GameObject POneGenreCodesUI;
    public Item POneLighterItem;
    public Item POneGenreCodesPaperItem;
    [HideInInspector]
    public LightmapSwitch POneLighmapSwitch;

    [Header("Second Puzzle References")]
    
    public GameObject PTwoControllerContainer;
    public GameObject PTwoMaleWC;
    public GameObject PTwoFemaleWC;
    public GameObject PTwoTV;
    

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
