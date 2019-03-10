using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleOneController : MonoBehaviour {

    public bool powerEnabled;
    public bool puzzleSolved;

    private Light[] _lights;
    private ReferencesManager _referencesManager;

    void Awake()
    {
        _referencesManager = ReferencesManager.instance;
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
            Debug.Log("puzzle 1 solucionado");
            GameManager.instance.SetPuzzleEnvironment(++GameManager.instance.currentPuzzle);
            Destroy(this);
        }
	}

    void ConfigureLevelOne()
    {
        LightmapSettings.lightmaps = _referencesManager.POneLighmapSwitch._firstLightMaps;
        _referencesManager.POneLightSwitch.transform.SetParent(_referencesManager.POneControllerContainer.transform);
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
