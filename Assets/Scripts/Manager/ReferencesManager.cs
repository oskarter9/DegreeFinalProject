using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesManager : MonoBehaviour
{
    public static ReferencesManager instance = null;

    public GameObject PlayerObjectsContainer;
    public GameObject RestrictedZones;
    public Player Player;
    public Camera CameraSceneA;
    public Camera CameraSceneB;
    public GameObject SoundClueSource;
    public UIPanels CanvasPanels;
    public ReflectionProbe[] ReflectiveObjects;
    public DialogueTrigger CurrentStoryDialogue;
    [HideInInspector]
    public bool ActiveDialogueBox = true;

    [Header("First Puzzle References")]

    public Light[] POneLights;
    public AudioSource POneTobaccoMachine;
    public GameObject[] POneFans;
    public GameObject POneFluorescentsContainer;
    public GameObject[] POneMainRoomLightsContainer;
    public GameObject POneLightSwitch;
    public GameObject POneControllerContainer;
    public GameObject POneGenreCodesPaper;
    public Transform POneGenreCodesPaperContainer;
    public Item POneLighterItem;
    public Item POneGenreCodesPaperItem;
    [HideInInspector]
    public LightmapSwitch POneLighmapSwitch;

    [Header("Second Puzzle References")]
    
    public GameObject PTwoControllerContainer;
    public GameObject PTwoMaleWC;
    public GameObject PTwoFemaleWC;
    public GameObject PTwoTV;

    [Header("Third Puzzle References")]

    public GameObject PThreeControllerContainer;
    public GameObject PThreeMorseLight;
    public GameObject PThreeMorseInputDevice;
    public Item PThreeTimeDevice;

    [Header("Fourth Puzzle References")]

    public GameObject PFourControllerContainer;

    private PlayerMove _playerMovement;
    private PlayerLook _cameraRotation;
    private TwinCameraController _swapCamera;

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
        _playerMovement = Player.GetComponentInChildren<PlayerMove>();
        _cameraRotation = Player.GetComponentInChildren<PlayerLook>();
        //_swapCamera = Player.GetComponentInChildren<TwinCameraController>();
    
        POneLighmapSwitch = GetComponentInChildren<LightmapSwitch>();
    }

    public void EnablePlayer()
    {
        EnablePlayerMovement();
        _cameraRotation.enabled = true;
        ActiveDialogueBox = true;
        //_swapCamera.enabled = true;
    }

    public void DisablePlayer()
    {
        DisablePlayerMovement();
        _cameraRotation.enabled = false;
        ActiveDialogueBox = false;
        //_swapCamera.enabled = false;
    }

    public void EnablePlayerMovement()
    {
        _playerMovement.enabled = true;
    }

    public void DisablePlayerMovement()
    {
        _playerMovement.enabled = false;
    }

    public void LockCursorManager(bool locked)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void DisableReflectionProbes()
    {
        foreach (var reflection in ReflectiveObjects)
        {
            reflection.enabled = false;
        }
    }

    public void EnableReflectionProbes()
    {
        foreach (var reflection in ReflectiveObjects)
        {
            reflection.enabled = true;
        }
    }
}
