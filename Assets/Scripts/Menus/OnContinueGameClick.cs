using System.Collections;
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
        PlayerPrefs.SetInt("SomethingToLoad", 1);
        SceneChangerAC.SetTrigger("ContinueFadeOut");
    }

    private IEnumerator LoadSceneAsync(int buildIndex)
    {
        if (_ableToLoad)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Single);

            while (!async.isDone)
            {
                yield return null;
            }

            AsyncOperation async2 = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            //AsyncOperation async2 = SceneManager.UnloadSceneAsync(0);

            while (!async2.isDone)
                yield return null;

            SceneManager.SetActiveScene(SceneManager.GetSceneAt(buildIndex));
        }
    }

    public void OnContinueFadeOut()
    {
        _ableToLoad = true;
        StartCoroutine(LoadSceneAsync(_sceneToGo));
    }
}
