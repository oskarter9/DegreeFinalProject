using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class PuzzleSelector : MonoBehaviour {

    public Button[] PuzzleButtons;

    private int _currentPuzzle;

	// Use this for initialization
	void Start () {
        
        if (PlayerPrefs.GetInt("SomethingToLoad") != 0)
        {
            _currentPuzzle = PlayerPrefs.GetInt("CurrentPuzzle");
            for (int i = 0; i < _currentPuzzle; i++)
            {
                PuzzleButtons[i].interactable = true;
            }
        }
    }
	
	public void SetCurrentPuzzle(int puzzleNumber)
    {
        PlayerPrefs.SetInt("CurrentPuzzle", puzzleNumber);
    }
}
