using System.Collections;
using System.Collections.Generic;
using UnityEngine.PostProcessing;
using UnityEngine;

public class TimeTravelAnimHelper : MonoBehaviour {

    public PostProcessingProfile PostProcProf;

    [SerializeField]
    private AnimationCurve _vignetteIntensity;

    [SerializeField]
    private AnimationCurve _chromaticAberrationIntensity;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
