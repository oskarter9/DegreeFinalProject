using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GamePaused = false;
    public GameObject PauseMenuUI;

    private PlayerLook _cameraRotation;
    private TwinCameraController _swapCamera;

    private void Start()
    {
        _cameraRotation = ReferencesManager.instance.Player.GetComponentInChildren<PlayerLook>();
        _swapCamera = ReferencesManager.instance.Player.GetComponentInChildren<TwinCameraController>();
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
        Time.timeScale = 1f;
        GamePaused = false;
        LockCursorManager(false);
        EnableCamerasFunction();
        SceneManager.LoadScene("MainMenu");
    }


    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        LockCursorManager(true);
        EnableCamerasFunction();
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        LockCursorManager(false);
        DisableCamerasFunction();
    }

    void LockCursorManager(bool locked)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void DisableCamerasFunction()
    {
        _cameraRotation.enabled = false;
        _swapCamera.enabled = false;
    }

    void EnableCamerasFunction()
    {
        _cameraRotation.enabled = true;
        _swapCamera.enabled = true;
    }
}
