using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwoController : MonoBehaviour {

    public bool puzzleSolved;

    private ReferencesManager _referencesManager;
    private GameObject _soundClueEmitter;

    void Awake()
    {
        _referencesManager = ReferencesManager.instance;
        ConfigureLevelTwo();
    }

    void Update()
    {
        if (puzzleSolved)
        {
            GameManager.instance.SetPuzzleEnvironment(++GameManager.instance.currentPuzzle);
            DestroyElements();
        }
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
