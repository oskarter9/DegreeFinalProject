using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseInputManager : MonoBehaviour {

    [HideInInspector]
    public List<char> MorseInput;
    [HideInInspector]
    public bool CheckMorseCode;

    private string _currentMorseCode;
    private ReferencesManager _referencesManager;
    private SoundsManager _soundsManager;
    private Animator _morseInputAC;
    private PlayerLook _cameraRotation;
    private TwinCameraController _swapCamera;
    // Use this for initialization
    void Start () {
        _referencesManager = ReferencesManager.instance;
        _soundsManager = SoundsManager.instance;
        _cameraRotation = ReferencesManager.instance.Player.GetComponentInChildren<PlayerLook>();
        _swapCamera = ReferencesManager.instance.Player.GetComponentInChildren<TwinCameraController>();
        _morseInputAC = _referencesManager.PThreeMorseInputUI.GetComponent<Animator>();
        MorseInput = new List<char>();
	}
	
	// Update is called once per frame
	void Update () {
        if (CheckMorseCode)
        {
            if (ValidMorseCode())
            {
                _morseInputAC.Play("CloseGamePanel");
                LockCursorManager(false);
                Cursor.visible = false;
                EnableCamerasFunction();
                _referencesManager.PThreeControllerContainer.GetComponent<PuzzleThreeController>().puzzleSolved = true;
            }
            else
            {
                _soundsManager.PlaySFX(_soundsManager.SFXSource, _soundsManager.BadCodeInput);
            }
            CheckMorseCode = false;
            MorseInput.Clear();
        }
	}

    bool ValidMorseCode()
    {
        char[] listToArray = MorseInput.ToArray();
        _currentMorseCode = ReferencesManager.instance.PThreeMorseLight.GetComponent<MorseGenerator>().CodeToShow;

        if (listToArray.Length != _currentMorseCode.Length)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < listToArray.Length; i++)
            {
                if (listToArray[i] != _currentMorseCode[i])
                {
                    return false;
                }
            }
            return true;
        }
    }

    void LockCursorManager(bool locked)
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

    void EnableCamerasFunction()
    {
        _cameraRotation.enabled = true;
        _swapCamera.enabled = true;
    }
}
