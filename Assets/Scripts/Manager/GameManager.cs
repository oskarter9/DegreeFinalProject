using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public int currentPuzzle;

    private bool _gameFinished;
    private ReferencesManager _referencesManager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        Cursor.visible = false;
    }
    void Start()
    {
        //SetGameVolume();
        _referencesManager = ReferencesManager.instance;
        if (PlayerPrefs.GetInt("SomethingToLoad") == 1)
        {
            //_referencesManager.Player.LoadPlayer();
            currentPuzzle = 1;
        }
        else
        {
            currentPuzzle = 1;
        }
        //SetEnvironmentVestiges(currentPuzzle);
        SetPuzzleEnvironment(currentPuzzle);
    }

    public void SetPuzzleEnvironment(int currentPuzzle)
    {
        switch (currentPuzzle)
        {
            case 1:
                _referencesManager.POneControllerContainer.AddComponent<PuzzleOneController>();
                break;
            case 2:
                _referencesManager.PTwoControllerContainer.AddComponent<PuzzleTwoController>();
                break;
            case 3:
                Debug.Log("Pasamos a puzzle 3");
                break;
        }
    }

    public void SetEnvironmentVestiges(int currentPuzzle)
    {
        switch (currentPuzzle)
        {
            case 2:
                var pOne = _referencesManager.POneControllerContainer.AddComponent<PuzzleOneController>();
                pOne.SetPuzzleOneVestiges();
                break;
            case 3:
                var pTwo = _referencesManager.PTwoControllerContainer.AddComponent<PuzzleTwoController>();
                pTwo.SetPuzzleTwoVestiges();
                break;
            default:
                break;
        }
    }

    private void SetGameVolume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("GeneralVolume");
    }
}

