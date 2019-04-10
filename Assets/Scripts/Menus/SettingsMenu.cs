﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
using UnityEngine;


public class SettingsMenu : MonoBehaviour {

    public TMP_Dropdown ResolutionDropdown;
    public PostProcessingProfile PostProcProf;

    private Resolution[] _resolutions;

    void Start()
    {
        _resolutions = Screen.resolutions;

        ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + "x" + _resolutions[i].height;
            options.Add(option);

            if(_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(options);
        ResolutionDropdown.value = currentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();

        PlayerPrefs.SetFloat("GeneralVolume", 1);
    }

	public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("GeneralVolume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = _resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetBloomEffect(bool bloomActive)
    {
        PostProcProf.bloom.enabled = bloomActive;
    }

    public void SetVignetteEffect(bool vignetteActive)
    {
        PostProcProf.vignette.enabled = vignetteActive;
    }

    public void SetMBEffect(bool mbActive)
    {
        PostProcProf.motionBlur.enabled = mbActive;
    }
}
