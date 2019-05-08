using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookGenresCode : MonoBehaviour {

    private GameObject _lookGenresCodeUI;

    private bool _lookingPaper = false;
    private Animator _lookGenresCodeAnimator;
    private UIPanels _canvas;

    void Start()
    {
        _canvas = ReferencesManager.instance.CanvasPanels;
        _lookGenresCodeAnimator = _canvas.GenresPaper.GetComponent<Animator>();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_lookingPaper)
            {
                _lookingPaper = true;
                _lookGenresCodeAnimator.Play("OpenGamePanel");
            }
            else
            {
                _lookingPaper = false;
                _lookGenresCodeAnimator.Play("CloseGamePanel");
            }
        }
    }
}
