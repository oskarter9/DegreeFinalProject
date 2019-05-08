using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public bool GamePaused = false;
    public GameObject PauseMenuUI;

    private ReferencesManager _referencesManager;
    private Animator _pauseMenuAC;

    private void Start()
    {
        _referencesManager = ReferencesManager.instance;
        _pauseMenuAC = PauseMenuUI.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q))
        {  
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void LoadMenu()
    {
        GamePaused = false;
        _referencesManager.LockCursorManager(false);
        Cursor.visible = true;
        _referencesManager.EnablePlayer();
        ReferencesManager.instance.Player.SavePlayer();
        ReferencesManager.instance.CameraSceneB.GetComponent<PostProcessDepthGrayscale>().enabled = false;
        PlayerPrefs.SetInt("SomethingToLoad", 1);
        SceneManager.LoadScene("MainMenu");
    }


    public void Resume()
    {
        _pauseMenuAC.Play("PausePanelOut");
        GamePaused = false;
        _referencesManager.LockCursorManager(true);
        Cursor.visible = false;
        _referencesManager.EnablePlayer();
    }

    void Pause()
    {
        _pauseMenuAC.Play("PausePanelIn");
        GamePaused = true;
        Cursor.visible = true;
        _referencesManager.LockCursorManager(false);
        _referencesManager.DisablePlayer();
    }
}
