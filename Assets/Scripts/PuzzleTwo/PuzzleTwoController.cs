using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwoController : MonoBehaviour {

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
        ConfigureLevelTwo();
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

    public void SetPuzzleTwoVestiges()
    {
        DestroyElements();
    }

    void ConfigureLevelTwo()
    {
        _referencesManager.PTwoControllerContainer.AddComponent<WCCodeFeature>();
        _soundClueEmitter = Instantiate(_referencesManager.SoundClueSource, transform);
        SetToilets();
    }

    void SetToilets()
    {
        _referencesManager.PTwoFemaleWC.transform.SetParent(_referencesManager.PTwoControllerContainer.transform);
        _referencesManager.PTwoMaleWC.transform.SetParent(_referencesManager.PTwoControllerContainer.transform);
        _referencesManager.PTwoFemaleWC.AddComponent<WCWomenWriter>();
        _referencesManager.PTwoMaleWC.AddComponent<WCMenWriter>();
    }

    void DestroyElements()
    {
        Destroy(_soundClueEmitter);
        Destroy(GetComponentInChildren<WCWomenWriter>());
        Destroy(GetComponentInChildren<WCMenWriter>());
        Destroy(GetComponent<WCCodeFeature>());
        Destroy(this);
    }
}
