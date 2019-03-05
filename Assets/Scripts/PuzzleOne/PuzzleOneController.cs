using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleOneController : MonoBehaviour {

    public bool puzzleSolved;

    private int _currentPuzzle;
    private Light[] _lights;
    private GameObject _lightSwitch;
    private ReferencesManager _referencesManager;

    void Awake()
    {
        _referencesManager = ReferencesManager.instance;
        _currentPuzzle = GameManager.instance.currentPuzzle;
        _lights = ReferencesManager.instance.POneLights;
        ConfigureLevelOne();
    }

	void Update () {
        if (puzzleSolved)
        {
            TurnOnLights(_lights);
            LightmapSettings.lightmaps = _referencesManager.POneLighmapSwitch._secondLightMaps;
            GameManager.instance.SetPuzzleEnvironment(_currentPuzzle + 1);
            puzzleSolved = false;
        }
	}

    void ConfigureLevelOne()
    {
        LightmapSettings.lightmaps = _referencesManager.POneLighmapSwitch._firstLightMaps;
        _lightSwitch = Instantiate(_referencesManager.POneLightSwitch, gameObject.transform);
        Inventory.instance.Add(_referencesManager.POneLighterItem);
        TurnOffLights(_lights);
    }

    void TurnOnLights(Light[] lights)
    {
        foreach (var light in lights)
        {
            light.intensity = .5f;
        }
    }

    void TurnOffLights(Light[] lights)
    {
        foreach (var light in _lights)
        {
            light.intensity = 0;
        }
    }
}
