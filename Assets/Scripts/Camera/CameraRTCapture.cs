﻿using UnityEngine;

[ExecuteInEditMode]
public class CameraRTCapture : MonoBehaviour {

    public Material Mat;

	void Start ()
    {
       GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Mat);
    }
}