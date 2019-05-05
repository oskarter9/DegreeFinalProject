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

    // Use this for initialization
    void Start () {
        _referencesManager = ReferencesManager.instance;
        _soundsManager = SoundsManager.instance;
        _morseInputAC = _referencesManager.PThreeMorseInputUI.GetComponent<Animator>();
        MorseInput = new List<char>();
	}
	
	// Update is called once per frame
	void Update () {
        if (CheckMorseCode)
        {
            if (ValidMorseCode())
            {
                _referencesManager.PThreeMorseInputUI.GetComponent<MorseUIManager>().InputDeviceOpened = false;
                _morseInputAC.Play("CloseGamePanel");
                _referencesManager.LockCursorManager(false);
                Cursor.visible = false;
                _referencesManager.EnablePlayer();
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
        _currentMorseCode = _referencesManager.PThreeMorseLight.GetComponent<MorseGenerator>().CodeToShow;

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
}
