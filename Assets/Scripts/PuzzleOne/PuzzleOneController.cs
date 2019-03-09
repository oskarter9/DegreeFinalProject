using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleOneController : MonoBehaviour {

    public bool powerEnabled;
    public bool puzzleSolved;

    private int _currentPuzzle;
    private Light[] _lights;
    private ReferencesManager _referencesManager;

    void Awake()
    {
        _referencesManager = ReferencesManager.instance;
        _currentPuzzle = GameManager.instance.currentPuzzle;
        _lights = ReferencesManager.instance.POneLights;
        ConfigureLevelOne();
    }

	void Update () {
        if (powerEnabled)
        {
            TurnOnLights(_lights);
            LightmapSettings.lightmaps = _referencesManager.POneLighmapSwitch._secondLightMaps;
            powerEnabled = false;
            
        }
        if (puzzleSolved)
        {
            GameManager.instance.SetPuzzleEnvironment(_currentPuzzle + 1);
            Destroy(this);
        }
	}

    void ConfigureLevelOne()
    {
        LightmapSettings.lightmaps = _referencesManager.POneLighmapSwitch._firstLightMaps;
        Instantiate(_referencesManager.POneLightSwitch, gameObject.transform);
        Instantiate(_referencesManager.POneGenreCodesPaper, gameObject.transform);
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
