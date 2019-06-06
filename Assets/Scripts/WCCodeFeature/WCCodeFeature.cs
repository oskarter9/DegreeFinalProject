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
    public List<int> PlayerInput = new List<int>();

    [HideInInspector]
    public float Counter = 0;
    [HideInInspector]
    public float _flushDelay;

    private SoundsManager _soundsManager;
    private ReferencesManager _referencesManager;
    private GameObject _tvScreen;

    private void Awake()
    {
        _soundsManager = SoundsManager.instance;
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
        
        if (_currentCode < 1)
        {
            if (PlayerInput.Count == 3)
            {
                if(Counter > _flushDelay)
                {
                    if (!CheckCorrectCode())
                    {
                        _soundsManager.PlaySFX(_soundsManager.SFXPuzzleTwoSource, _soundsManager.WrongSound);
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

        ShowCodeInTv();
        PlayerInput.Clear();
        _currentCode += 1;
        return true;
    }

    private void ShowCodeInTv()
    {
        if (_currentCode == 0)
        {
            _tvScreen.GetComponent<TVScreenManager>().AvailableTextures.Add(_tvScreen.GetComponent<TVScreenManager>().MorseTranslationTextures[_currentCode]);
            _tvScreen.GetComponent<AudioSource>().clip = _soundsManager.TVSynthLoop;
            _tvScreen.GetComponent<AudioSource>().Play();
            StartCoroutine(_tvScreen.GetComponent<TVScreenManager>().IterateTextures());
        }
        else
        {
            _tvScreen.GetComponent<TVScreenManager>().AvailableTexturesToAdd.Add(_tvScreen.GetComponent<TVScreenManager>().MorseTranslationTextures[_currentCode]);
        }
    }
}
