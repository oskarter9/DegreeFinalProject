using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwoController : MonoBehaviour {

    public bool puzzleSolved;

    private ReferencesManager _referencesManager;

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
        _referencesManager.PTwoControllerContainer.AddComponent<AudioSource>();
        _referencesManager.PTwoControllerContainer.AddComponent<WCCodeFeature>();
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
        Destroy(GetComponentInChildren<WCWomenWriter>());
        Destroy(GetComponentInChildren<WCMenWriter>());
        Destroy(GetComponent<WCCodeFeature>());
        Destroy(this);
    }
}
