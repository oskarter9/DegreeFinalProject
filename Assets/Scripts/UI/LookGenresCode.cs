﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookGenresCode : MonoBehaviour {

    private GameObject _lookGenresCodeUI;

    private bool _lookingPaper = false;
    private Animator _lookGenresCodeAnimator;

    void Start()
    {
        _lookGenresCodeUI = ReferencesManager.instance.POneGenreCodesUI;
        _lookGenresCodeAnimator = _lookGenresCodeUI.GetComponent<Animator>();
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
