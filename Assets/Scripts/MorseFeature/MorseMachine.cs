using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseMachine : Interactable {

    private GameObject _morseInputUI;
    private Animator _morseInputAC;

    private PlayerLook _cameraRotation;
    private TwinCameraController _swapCamera;

    public override void Interact()
    {
        base.Interact();
        OpenInputDevice();
    }

    void Start()
    {
        _morseInputUI = ReferencesManager.instance.PThreeMorseInputUI;
        _morseInputAC = _morseInputUI.GetComponent<Animator>();
        _cameraRotation = ReferencesManager.instance.Player.GetComponentInChildren<PlayerLook>();
        _swapCamera = ReferencesManager.instance.Player.GetComponentInChildren<TwinCameraController>();
    }

    private void OpenInputDevice()
    {
        _morseInputAC.Play("OpenGamePanel");
        LockCursorManager(false);
        Cursor.visible = true;
        DisableCamerasFunction();
        _morseInputUI.GetComponent<MorseUIManager>().InputDeviceOpened = true;
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

    void DisableCamerasFunction()
    {
        _cameraRotation.enabled = false;
        _swapCamera.enabled = false;
    }
}
