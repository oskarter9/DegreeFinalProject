using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleOneController : MonoBehaviour {

    public bool powerEnabled;
    public bool puzzleSolved;

    private Light[] _lights;
    private ReferencesManager _referencesManager;
    private GameObject _soundClueEmitter;
    private GameObject _paperGenresCodes;
    private SoundsManager _soundsManager;

    void Awake()
    {
        _soundsManager = SoundsManager.instance;
        _referencesManager = ReferencesManager.instance;
        _lights = ReferencesManager.instance.POneLights;
        if(GameManager.instance.currentPuzzle == 1)
        {
            ConfigureLevelOne();
        }
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
            _soundsManager.PlaySFX(_soundsManager.SFXSource,_soundsManager.CorrectPuzzle);
            Destroy(_soundClueEmitter);
            Destroy(this);
        }
	}

    public void SetPuzzleOneVestiges()
    {
        TurnOnLights(_lights);
        LightmapSettings.lightmaps = _referencesManager.POneLighmapSwitch._secondLightMaps;
        _referencesManager.POneLightSwitch.GetComponent<LightSwitchPOne>().enabled = false;
        Inventory.instance.Add(_referencesManager.POneGenreCodesPaperItem);
        Inventory.instance.Add(_referencesManager.POneLighterItem);
        Destroy(this);
    }

    void ConfigureLevelOne()
    {
        LightmapSettings.lightmaps = _referencesManager.POneLighmapSwitch._firstLightMaps;
        _referencesManager.POneLightSwitch.transform.SetParent(_referencesManager.POneControllerContainer.transform);
        _paperGenresCodes = Instantiate(_referencesManager.POneGenreCodesPaper, _referencesManager.POneGenreCodesPaperContainer);
        _paperGenresCodes.GetComponent<LookGenresCode>().enabled = false;
        _soundClueEmitter = Instantiate(_referencesManager.SoundClueSource,transform);
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
