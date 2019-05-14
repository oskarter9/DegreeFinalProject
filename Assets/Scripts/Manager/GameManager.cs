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
        _referencesManager = ReferencesManager.instance;
        if (PlayerPrefs.GetInt("SomethingToLoad") == 1)
        {
            _referencesManager.Player.LoadPlayer();
            for (int i = 1; i <= currentPuzzle; i++)
            {
                SetEnvironmentVestiges(i);
            }
        }
        else
        {
            currentPuzzle = 1;
        }
        SetCamerasRenderingPath();
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
                _referencesManager.PThreeControllerContainer.AddComponent<PuzzleThreeController>();
                break;
            case 4:
                _referencesManager.PFourControllerContainer.AddComponent<PuzzleFourController>();
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
            case 4:
                var pThree = _referencesManager.PThreeControllerContainer.AddComponent<PuzzleThreeController>();
                pThree.SetPuzzleThreeVestiges();
                break;
            default:
                break;
        }
    }

    public void LoadSceneAdditive(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Additive);
    }

    private void SetGameVolume()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("GeneralVolume");
    }

    private void SetCamerasRenderingPath()
    {
        if(PlayerPrefs.GetInt("RefQuality") == 1)
        {
            _referencesManager.CameraSceneA.renderingPath = RenderingPath.DeferredShading;
            _referencesManager.CameraSceneB.renderingPath = RenderingPath.DeferredShading;
        }
        else
        {
            _referencesManager.CameraSceneA.renderingPath = RenderingPath.Forward;
            _referencesManager.CameraSceneB.renderingPath = RenderingPath.Forward;
        }
    }
}

