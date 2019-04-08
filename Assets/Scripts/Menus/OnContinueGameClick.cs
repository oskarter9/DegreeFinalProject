﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnContinueGameClick : MonoBehaviour {

    public Animator SceneChangerAC;

    private int _sceneToGo;
    private bool _ableToLoad;

    public void LoadGame(int buildIndex)
    {
        _sceneToGo = buildIndex;
        //Esto de abajo hay que cambiarlo porque si que deberia haber algo que cargar
        PlayerPrefs.SetInt("SomethingToLoad", 0);
        SceneChangerAC.SetTrigger("FadeOut");
    }

    private IEnumerator LoadSceneAsync(int buildIndex)
    {
        if (_ableToLoad)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);

            while (!async.isDone)
            {
                yield return null;
            }

            AsyncOperation async2 = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

            while (!async2.isDone)
                yield return null;

            SceneManager.SetActiveScene(SceneManager.GetSceneAt(buildIndex));
        }
    }

    public void OnFadeOut()
    {
        _ableToLoad = true;
        StartCoroutine(LoadSceneAsync(_sceneToGo));
    }
}