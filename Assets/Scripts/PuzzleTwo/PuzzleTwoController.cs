using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwoController : MonoBehaviour {

    public bool puzzleSolved;

    private ReferencesManager _referencesManager;
    private GameObject _soundClueEmitter;
    private SoundsManager _soundsManager;
    private DialogueTrigger _currentTrigger;
    private Material _tvScreenMaterial;
    private GameObject _tvScreen;

    void Awake()
    {
        _soundsManager = SoundsManager.instance;
        _referencesManager = ReferencesManager.instance;
        _tvScreen = _referencesManager.PTwoTV;
        _currentTrigger = GetComponent<DialogueTrigger>();
        _referencesManager.CurrentStoryDialogue = _currentTrigger;
        
        _tvScreenMaterial = _tvScreen.GetComponent<MeshRenderer>().material;
        if (GameManager.instance.currentPuzzle == 2)
        {
            _currentTrigger.TriggerDialogue();
            ConfigureLevelTwo();
        }
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
        _tvScreenMaterial.EnableKeyword("_EMISSION");
        _tvScreen.GetComponent<TVScreenManager>().AvailableTextures.AddRange(_tvScreen.GetComponent<TVScreenManager>().MorseTranslationTextures);
        StartCoroutine(_tvScreen.GetComponent<TVScreenManager>().IterateTextures());
        DestroyElements();
    }

    void ConfigureLevelTwo()
    {
        _referencesManager.PTwoControllerContainer.AddComponent<WCCodeFeature>();
        _tvScreenMaterial.EnableKeyword("_EMISSION");
        _soundClueEmitter = Instantiate(_referencesManager.SoundClueSource, transform);
        SetToilets();
    }

    void SetToilets()
    {
        _referencesManager.PTwoFemaleWC.transform.SetParent(_referencesManager.PTwoControllerContainer.transform);
        _referencesManager.PTwoMaleWC.transform.SetParent(_referencesManager.PTwoControllerContainer.transform);
        _referencesManager.PTwoFemaleWC.AddComponent<WCWriter>();
        _referencesManager.PTwoFemaleWC.GetComponent<WCWriter>().CodeToInput = 1;
        _referencesManager.PTwoMaleWC.AddComponent<WCWriter>();
        _referencesManager.PTwoMaleWC.GetComponent<WCWriter>().CodeToInput = 0;
    }

    void DestroyElements()
    {
        Destroy(_soundClueEmitter);
        Destroy(_referencesManager.PTwoMaleWC.GetComponent<WCWriter>());
        Destroy(_referencesManager.PTwoFemaleWC.GetComponent<WCWriter>());
        Destroy(GetComponent<WCCodeFeature>());
        Destroy(this);
    }
}
