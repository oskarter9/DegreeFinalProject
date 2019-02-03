﻿using UnityEngine;
using UnityEngine.Rendering;

public class TwinCameraController : MonoBehaviour
{
    public RenderTexture initialRT;

    [SerializeField]
    private Camera _activeCamera;
    public Material _activeCameraMat;
    [SerializeField]
    private Camera _hiddenCamera;
    private Material _hiddenCameraMat;

    private float timeToChangeScene = 3f;
    private float currentTime = 4f;

    public void SwapCameras()
    {
        _activeCamera.targetTexture = _hiddenCamera.targetTexture;
        _hiddenCamera.targetTexture = null;

        var swapCamera = _activeCamera;
        _activeCamera = _hiddenCamera;
        _hiddenCamera = swapCamera;

        _activeCameraMat.SetFloat("_RunRingPass", 0);
        _hiddenCamera.GetComponent<PostProcessDepthGrayscale>().enabled = false;
        _activeCamera.GetComponent<PostProcessDepthGrayscale>().enabled = true;
    }

    private void Awake()
    {
        _activeCameraMat = _activeCamera.GetComponent<PostProcessDepthGrayscale>().mat;
        _hiddenCamera.GetComponent<PostProcessDepthGrayscale>().enabled = false;
        _activeCameraMat.SetFloat("_RunRingPass", 0);
        _hiddenCamera.targetTexture = initialRT;
    }

    void Update()
    {
        if (TimeElapsed())
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                currentTime = 0f;
                ChangeSceneMat();
                Invoke("SwapCameras", 2.1f);
            }
        }
        
    }

    private void ChangeSceneMat()
    {
        _activeCameraMat.SetTexture("_AnotherTex", _hiddenCamera.targetTexture);
        _activeCameraMat.SetFloat("_StartingTime", Time.time);
        _activeCameraMat.SetFloat("_RunRingPass", 1);
        _activeCameraMat.SetFloat("_RingWidth", 0.001f);
    }

    private bool TimeElapsed()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= timeToChangeScene)
        {
            return true;
        }
        return false;
    }
}