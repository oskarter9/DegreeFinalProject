﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UniverseController : MonoBehaviour {

	void Awake()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }
}
