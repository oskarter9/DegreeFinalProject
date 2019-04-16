﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCCodeFeature : MonoBehaviour {

    private int _currentCode = 0;

    private int[][] _codeSet;

    //M = Masculino, F = Femenino
    private readonly int[] _firstCode = { 1, 0, 0 }; //F,M,M
    private readonly int[] _secondCode = { 1, 0, 1 }; //F,M,F
    private readonly int[] _thirdCode = { 0, 0, 1 }; //M,M,F
    private readonly int[] _fourthCode = { 1, 1, 0 }; //F,F,M


    [HideInInspector]
    public List<int> PlayerInput = new List<int>();

    [HideInInspector]
    public float Counter = 0;
    [HideInInspector]
    public float _flushDelay;

    private SoundsManager _wCSoundManager;
    private ReferencesManager _referencesManager;
    private GameObject _tvScreen;
    private AudioClip _wrongSound;
    private AudioClip _correctSound;

    private void Awake()
    {
        _wCSoundManager = SoundsManager.instance;
        _referencesManager = ReferencesManager.instance;
        _tvScreen = _referencesManager.PTwoTV;
        _flushDelay = SoundsManager.instance.ToiletFlush.length;
        _codeSet = new int[4][];
        _codeSet[0] = _firstCode;
        _codeSet[1] = _secondCode;
        _codeSet[2] = _thirdCode;
        _codeSet[3] = _fourthCode;
    }

    private void Update()
    {
        if(Counter <= _flushDelay + 1)
        {
            Counter += Time.deltaTime;
        }
        
        if (_currentCode < 4)
        {
            if (PlayerInput.Count == 3)
            {
                if(Counter > _flushDelay)
                {
                    if (!CheckCorrectCode())
                    {
                        _wCSoundManager.PlaySFX(_wCSoundManager.SFXPuzzleTwoSource, _wCSoundManager.WrongSound);
                    }
                }
                
            }
        }
        else
        {
            GetComponent<PuzzleTwoController>().puzzleSolved = true;
        }
    }

    private bool CheckCorrectCode()
    {
        for (int i = 0; i < PlayerInput.Count; i++)
        {
            if (PlayerInput[i] != _codeSet[_currentCode][i])
            {
                PlayerInput.Clear();
                return false;
            }
        }

        if (_currentCode == 0)
        {
            _tvScreen.GetComponent<TVScreenManager>().AvailableTextures.Add(_tvScreen.GetComponent<TVScreenManager>().MorseTranslationTextures[_currentCode]);
            StartCoroutine(_tvScreen.GetComponent<TVScreenManager>().IterateTextures());
        }
        else
        {
            _tvScreen.GetComponent<TVScreenManager>().AvailableTexturesToAdd.Add(_tvScreen.GetComponent<TVScreenManager>().MorseTranslationTextures[_currentCode]);
        }

        PlayerInput.Clear();
        _currentCode += 1;
        return true;
    }

}
