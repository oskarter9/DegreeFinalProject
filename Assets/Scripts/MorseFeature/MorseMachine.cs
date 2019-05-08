using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseMachine : Interactable {

    private GameObject _morseInputUI;
    private Animator _morseInputAC;

    private ReferencesManager _referencesManager;

    public override void Interact()
    {
        base.Interact();
        OpenInputDevice();
    }

    void Start()
    {
        _referencesManager = ReferencesManager.instance;
        _morseInputUI = _referencesManager.CanvasPanels.MorseInput;
        _morseInputAC = _morseInputUI.GetComponent<Animator>();
    }

    private void OpenInputDevice()
    {
        _morseInputAC.Play("OpenGamePanel");
        _referencesManager.LockCursorManager(false);
        Cursor.visible = true;
        _referencesManager.DisablePlayer();
        _morseInputUI.GetComponent<MorseUIManager>().InputDeviceOpened = true;
    }
}
