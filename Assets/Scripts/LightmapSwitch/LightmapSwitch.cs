using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightmapSwitch : MonoBehaviour {

    public Texture2D[] FirstLightMapDir;
    public Texture2D[] FirstLightMapLight;
    public Texture2D[] FirstLightMapSM;
    public Texture2D[] SecondLightMapDir;
    public Texture2D[] SecondLightMapLight;
    public Texture2D[] SecondLightMapSM;

    public LightmapData[] _firstLightMaps;
    public LightmapData[] _secondLightMaps;

    // Use this for initialization
    void Start () {

        if ((FirstLightMapDir.Length != FirstLightMapLight.Length || FirstLightMapDir.Length != FirstLightMapSM.Length) || (SecondLightMapDir.Length != SecondLightMapLight.Length || SecondLightMapDir.Length != SecondLightMapSM.Length))
        {
            Debug.Log("In order for LightMapSwitcher to work, the Near and Far LightMap lists must be of equal length");
            return;
        }

        FirstLightMapDir = FirstLightMapDir.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        FirstLightMapLight = FirstLightMapLight.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        FirstLightMapSM = FirstLightMapSM.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        SecondLightMapDir = SecondLightMapDir.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        SecondLightMapLight = SecondLightMapLight.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        SecondLightMapSM = SecondLightMapSM.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();

        _firstLightMaps = new LightmapData[FirstLightMapDir.Length];
        for (int i = 0; i < FirstLightMapDir.Length; i++)
        {
            _firstLightMaps[i] = new LightmapData();
            _firstLightMaps[i].lightmapDir = FirstLightMapDir[i];
            _firstLightMaps[i].lightmapColor = FirstLightMapLight[i];
            _firstLightMaps[i].shadowMask = FirstLightMapSM[i];
        }

        _secondLightMaps = new LightmapData[SecondLightMapDir.Length];
        for (int i = 0; i < SecondLightMapDir.Length; i++)
        {
            _secondLightMaps[i] = new LightmapData();
            _secondLightMaps[i].lightmapDir = SecondLightMapDir[i];
            _secondLightMaps[i].lightmapColor = SecondLightMapLight[i];
            _secondLightMaps[i].shadowMask = SecondLightMapSM[i];
        }
    }
}
