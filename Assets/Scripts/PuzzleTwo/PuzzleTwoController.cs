using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTwoController : MonoBehaviour {

    public bool puzzleSolved;

    private int _currentPuzzle;
    private ReferencesManager _referencesManager;

    void Awake()
    {
        _referencesManager = ReferencesManager.instance;
        _currentPuzzle = GameManager.instance.currentPuzzle;
        ConfigureLevelTwo();
    }

    void Update()
    {
        if (puzzleSolved)
        {
            LightmapSettings.lightmaps = _referencesManager.POneLighmapSwitch._secondLightMaps;
            GameManager.instance.SetPuzzleEnvironment(_currentPuzzle + 1);
            puzzleSolved = false;
            Destroy(this);
        }
    }

    void ConfigureLevelTwo()
    {
        LightmapSettings.lightmaps = _referencesManager.POneLighmapSwitch._firstLightMaps;
        Instantiate(_referencesManager.POneLightSwitch, gameObject.transform);
        Inventory.instance.Add(_referencesManager.POneLighterItem);
    }
}
