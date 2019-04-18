﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MorseUIManager : MonoBehaviour {

    [HideInInspector]
    public bool InputDeviceOpened;
    public TextMeshProUGUI DisplayText;

    private ReferencesManager _referencesManager;
    private GameObject _morseInputDevice;

    private int _charNumber = 0;

    private SoundsManager _soundManager;

    // Use this for initialization
    void Start () {
        _soundManager = SoundsManager.instance;
        _referencesManager = ReferencesManager.instance;
        _morseInputDevice = _referencesManager.PThreeMorseInputDevice;
    }
	
	// Update is called once per frame
	void Update () {
        if (InputDeviceOpened)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                GetComponent<Animator>().Play("CloseGamePanel");
                _referencesManager.LockCursorManager(true);
                Cursor.visible = false;
                _referencesManager.EnablePlayer();
                InputDeviceOpened = false;
                _morseInputDevice.GetComponent<MorseInputManager>().MorseInput.Clear();
                DisplayText.text = "";
                _charNumber = 0;
            }
        }
	}

    public void AddDigit(string digit)
    {
        if (_charNumber < 4)
        {
            _soundManager.PlaySFX(_soundManager.SFXSource, _soundManager.MorseCodeInput);
            DisplayText.text += digit.ToUpper();
            char digitChar = digit[0];
            _morseInputDevice.GetComponent<MorseInputManager>().MorseInput.Add(digitChar);
            _charNumber += 1;
        }
        else
        {
            _soundManager.PlaySFX(_soundManager.SFXSource, _soundManager.NoInteractable);
        }
    }

    public void ValidateCode()
    {
        _morseInputDevice.GetComponent<MorseInputManager>().CheckMorseCode = true;
        DisplayText.text = "";
        _charNumber = 0;
    }
}