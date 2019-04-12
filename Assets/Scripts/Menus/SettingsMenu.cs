using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.PostProcessing;
using UnityEngine;


public class SettingsMenu : MonoBehaviour {

    public Slider VolumeSlider;
    public TMP_Dropdown QualityDropdown;
    public Toggle FullScreenToggle;
    public TMP_Dropdown ResolutionDropdown;
    public Toggle BloomEffectToggle;
    public Toggle VignetteEffectToggle;
    public Toggle MBEffectToggle;
    public PostProcessingProfile PostProcProf;

    public Button ApplyChangesButton;
    public Button ResetDefaultChanges;

    public bool changesNotApplied;

    private Resolution[] _resolutions;

    void Start()
    {
        ApplyChangesButton.GetComponent<Button>().enabled = false;
        SetInitialSettings();
        GetInitialSettings();
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

        changesNotApplied = false;

    }

	public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("GeneralVolume", volume);
        EnableButton(ApplyChangesButton);
    }

    public void SetQuality (int qualityIndex)
    {
        PlayerPrefs.SetInt("QualityIndex", qualityIndex);
        EnableButton(ApplyChangesButton);
    }

    public void SetFullscreen(bool fullscreen)
    {
        PlayerPrefs.SetInt("FullScreen", BoolToInt(fullscreen));
        EnableButton(ApplyChangesButton);
    }

    public void SetResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        EnableButton(ApplyChangesButton);
    }

    public void SetBloomEffect(bool bloomActive)
    {
        PlayerPrefs.SetInt("BloomEffect", BoolToInt(bloomActive));
        EnableButton(ApplyChangesButton);
    }

    public void SetVignetteEffect(bool vignetteActive)
    {
        PlayerPrefs.SetInt("VignetteEffect", BoolToInt(vignetteActive));
        EnableButton(ApplyChangesButton);
    }

    public void SetMBEffect(bool mbActive)
    {
        PlayerPrefs.SetInt("MBEffect", BoolToInt(mbActive));
        EnableButton(ApplyChangesButton);
    }

    public void SetDefaultSettings()
    {
        SetVolume(1);
        SetQuality(5);
        SetFullscreen(true);
        SetResolution(Screen.resolutions.Length - 1);
        SetBloomEffect(true);
        SetVignetteEffect(true);
        SetMBEffect(true);
        ApplyChanges();
        SetInitialSettings();
        changesNotApplied = false;
    }

    public void RevertChanges()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("PrevGeneralVolume");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("PrevQualityIndex"));
        Screen.fullScreen = IntToBool(PlayerPrefs.GetInt("PrevFullScreen"));
        Resolution res = _resolutions[PlayerPrefs.GetInt("PrevResolutionIndex")];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        PostProcProf.bloom.enabled = IntToBool(PlayerPrefs.GetInt("PrevBloomEffect"));
        PostProcProf.vignette.enabled = IntToBool(PlayerPrefs.GetInt("PrevVignetteEffect"));
        PostProcProf.motionBlur.enabled = IntToBool(PlayerPrefs.GetInt("PrevMBEffect"));
        changesNotApplied = false;
    }

    public void ApplyChanges()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("GeneralVolume");
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityIndex"));
        Screen.fullScreen = IntToBool(PlayerPrefs.GetInt("FullScreen"));
        Resolution res = _resolutions[PlayerPrefs.GetInt("ResolutionIndex")];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        PostProcProf.bloom.enabled = IntToBool(PlayerPrefs.GetInt("BloomEffect"));
        PostProcProf.vignette.enabled = IntToBool(PlayerPrefs.GetInt("VignetteEffect"));
        PostProcProf.motionBlur.enabled = IntToBool(PlayerPrefs.GetInt("MBEffect"));
        changesNotApplied = false;
    }

    void SetInitialSettings()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("GeneralVolume");
        QualityDropdown.value = PlayerPrefs.GetInt("QualityIndex");
        ResolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex");
        FullScreenToggle.isOn = IntToBool(PlayerPrefs.GetInt("FullScreen"));
        BloomEffectToggle.isOn = IntToBool(PlayerPrefs.GetInt("BloomEffect"));
        VignetteEffectToggle.isOn = IntToBool(PlayerPrefs.GetInt("VignetteEffect"));
        MBEffectToggle.isOn = IntToBool(PlayerPrefs.GetInt("MBEffect"));
    }

    void GetInitialSettings()
    {
        PlayerPrefs.SetFloat("PrevGeneralVolume",PlayerPrefs.GetFloat("GeneralVolume"));
        PlayerPrefs.SetInt("PrevQualityIndex", PlayerPrefs.GetInt("QualityIndex"));
        PlayerPrefs.SetInt("PrevResolutionIndex",PlayerPrefs.GetInt("ResolutionIndex"));
        PlayerPrefs.SetInt("PrevFullScreen", PlayerPrefs.GetInt("FullScreen"));
        PlayerPrefs.SetInt("PrevBloomEffect", PlayerPrefs.GetInt("BloomEffect"));
        PlayerPrefs.SetInt("PrevVignetteEffect", PlayerPrefs.GetInt("VignetteEffect"));
        PlayerPrefs.SetInt("PrevMBEffect", PlayerPrefs.GetInt("MBEffect"));
    }

    void EnableButton(Button btn)
    {
        changesNotApplied = true;
        if (!btn.GetComponent<Button>().isActiveAndEnabled)
        {
            btn.enabled = true;
        }
    }

    bool IntToBool(int value)
    {
        if(value == 0)
        {
            return false;
        }
        else if(value == 1)
        {
            return true;
        }
        return false;
    }

    int BoolToInt(bool boolValue)
    {
        if (!boolValue)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
}
