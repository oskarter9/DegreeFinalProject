using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOneController : MonoBehaviour {

    public bool puzzleSolved;

    private int _currentPuzzle;
    private Light[] _lights;
    private GameObject _lightSwitch;
    private ReferencesManager _referencesManager;

    // Use this for initialization
    void Start () {
        _referencesManager = ReferencesManager.instance;
        _currentPuzzle = GameManager.instance.currentPuzzle;
        _lights = ReferencesManager.instance.POneLights;
        _lightSwitch = Instantiate(_referencesManager.POneLightSwitch, gameObject.transform);
        foreach (var light in _lights)
        {
            light.intensity = 0;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if (puzzleSolved)
        {
            foreach (var light in _lights)
            {
                light.intensity = 1.5f;
            }
            GameManager.instance.SetPuzzleEnvironment(_currentPuzzle + 1);
            puzzleSolved = false;
        }
	}
}
