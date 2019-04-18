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
    public GameObject[] POneMainRoomLightsContainer;
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

    [Header("Third Puzzle References")]

    public GameObject PThreeControllerContainer;
    public GameObject PThreeMorseLight;
    public GameObject PThreeMorseInputDevice;
    public GameObject PThreeMorseInputUI;

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
        _swapCamera = Player.GetComponentInChildren<TwinCameraController>();
    
        POneLighmapSwitch = GetComponentInChildren<LightmapSwitch>();
    }

    public void EnablePlayer()
    {
        _playerMovement.enabled = true;
        _cameraRotation.enabled = true;
        _swapCamera.enabled = true;
    }

    public void DisablePlayer()
    {
        _playerMovement.enabled = false;
        _cameraRotation.enabled = false;
        _swapCamera.enabled = false;
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
}
