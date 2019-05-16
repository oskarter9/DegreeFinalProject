using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButtonManager : MonoBehaviour {

    public Sprite[] LevelImages;
    public Image CurrentLevelImage;
    private Button _button;

	// Use this for initialization
	void Start () {
        _button = GetComponent<Button>();
        if (PlayerPrefs.GetInt("SomethingToLoad") != 0)
        {
            _button.interactable = true;
            CurrentLevelImage.sprite = LevelImages[PlayerPrefs.GetInt("CurrentPuzzle") - 1];
        }
        else
        {
            _button.interactable = false;
            
        }
	}
	
}
