using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnContinueGameClick : MonoBehaviour {

    public void LoadGame(int buildIndex)
    {
        StartCoroutine(LoadSceneAsync(buildIndex));
    }

    private IEnumerator LoadSceneAsync(int buildIndex)
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
