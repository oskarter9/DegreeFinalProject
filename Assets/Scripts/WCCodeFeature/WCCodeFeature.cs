using System.Collections;
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
    public List<int> PlayerInput;

    private AudioSource _wCSoundManager;
    public AudioClip WrongSound;
    public AudioClip CorrectSound;

    private void Awake()
    {
        _wCSoundManager = GetComponent<AudioSource>();
        _codeSet = new int[4][];
        _codeSet[0] = _firstCode;
        _codeSet[1] = _secondCode;
        _codeSet[2] = _thirdCode;
        _codeSet[3] = _fourthCode;
    }

    public void Update()
    {
        if(_currentCode < 4 && PlayerInput.Count == 3)
        {
            if (CheckCorrectCode())
            {
                _wCSoundManager.clip = CorrectSound;
                _wCSoundManager.Play();
            }
            else
            {
                _wCSoundManager.clip = WrongSound;
                _wCSoundManager.Play();
            }
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
        PlayerInput.Clear();
        _currentCode += 1;
        return true;
    }

}
