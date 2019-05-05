using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFourController : MonoBehaviour {

    private ReferencesManager _referencesManager;
    private DialogueTrigger _currentTrigger;

    // Use this for initialization
    void Start () {
        _referencesManager = ReferencesManager.instance;
        _currentTrigger = GetComponent<DialogueTrigger>();
        _referencesManager.CurrentStoryDialogue = _currentTrigger;
        _currentTrigger.TriggerDialogue();
    }
	
}
