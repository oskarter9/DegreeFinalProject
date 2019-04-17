using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleOneController : MonoBehaviour {

    [HideInInspector]
    public bool powerEnabled;
    [HideInInspector]
    public bool enablePaper;
    [HideInInspector]
    public bool puzzleSolved;

    private Light[] _lights;
    private GameObject[] _barLights;
    private ReferencesManager _referencesManager;
    private GameObject _soundClueEmitter;
    private GameObject _paperGenresCodes;
    private SoundsManager _soundsManager;
    private DialogueTrigger _currentTrigger;

    void Awake()
    {
        _soundsManager = SoundsManager.instance;
        _referencesManager = ReferencesManager.instance;
        _lights = _referencesManager.POneLights;
        _barLights = _referencesManager.POneMainRoomLightsContainer;
        _currentTrigger = GetComponent<DialogueTrigger>();
        _referencesManager.CurrentStoryDialogue = _currentTrigger;
        if(GameManager.instance.currentPuzzle == 1)
        {
            _currentTrigger.TriggerDialogue();
            ConfigureLevelOne();
        }
    }

	void Update () {
        if (powerEnabled)
        {
            LightmapSettings.lightmaps = _referencesManager.POneLighmapSwitch._secondLightMaps;
            TurnOnPower();
            powerEnabled = false;
            enablePaper = true;
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
        TurnOnPower();
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
        TurnOffLights();
    }
    void TurnOffLights()
    {
        foreach (var light in _lights)
        {
            light.intensity = 0;
        }
    }

    void TurnOnPower()
    {
        foreach (var fan in _referencesManager.POneFans)
        {
            fan.GetComponent<FanBehaviour>().EnableFan();
        }

        foreach (var light in _lights)
        {
            light.intensity = .8f;
        }

        foreach (var emissiveLight in _barLights)
        {
            emissiveLight.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        }

        _referencesManager.POneTobaccoMachine.Play();
        _referencesManager.PTwoTV.GetComponent<AudioSource>().Play();
        _referencesManager.POneFluorescentsContainer.GetComponent<FluorescentsBehaviour>().EnableFluorescents();
    }
}
