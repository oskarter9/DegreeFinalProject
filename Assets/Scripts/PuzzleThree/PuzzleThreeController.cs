using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleThreeController : MonoBehaviour {

    public bool puzzleSolved;

    private ReferencesManager _referencesManager;
    private GameObject _soundClueEmitter;
    private SoundsManager _soundsManager;
    private DialogueTrigger _currentTrigger;

    void Awake()
    {
        _soundsManager = SoundsManager.instance;
        _referencesManager = ReferencesManager.instance;
        _currentTrigger = GetComponent<DialogueTrigger>();
        _referencesManager.CurrentStoryDialogue = _currentTrigger;
        _currentTrigger.TriggerDialogue();
        ConfigureLevelThree();
    }

    void Update()
    {
        if (puzzleSolved)
        {
            _soundsManager.PlaySFX(_soundsManager.SFXSource, _soundsManager.CorrectPuzzle);
            GameManager.instance.SetPuzzleEnvironment(++GameManager.instance.currentPuzzle);
            DestroyElements();
        }
    }

    public void SetPuzzleThreeVestiges()
    {
        DestroyElements();
    }

    void ConfigureLevelThree()
    {
        _referencesManager.PThreeMorseLight.AddComponent<MorseGenerator>();
        _referencesManager.PThreeMorseInputDevice.AddComponent<MorseMachine>();
        _referencesManager.PThreeMorseInputDevice.AddComponent<MorseInputManager>();
        _soundClueEmitter = Instantiate(_referencesManager.SoundClueSource, transform);
    }

    void DestroyElements()
    {
        Destroy(_soundClueEmitter);
        Destroy(_referencesManager.PThreeMorseLight.GetComponent<MorseGenerator>());
        Destroy(_referencesManager.PThreeMorseInputDevice.GetComponent<MorseMachine>());
        Destroy(_referencesManager.PThreeMorseInputDevice.GetComponent<MorseInputManager>());
        Destroy(this);
    }
}
