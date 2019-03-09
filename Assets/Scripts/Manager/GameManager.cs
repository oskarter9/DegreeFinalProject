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

    // Use this for initialization
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
    }
    void Start()
    {
        _referencesManager = GetComponent<ReferencesManager>();
        currentPuzzle = 1;
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
}

