using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LightmapSwitch : MonoBehaviour {

    public Texture2D[] FirstLightMapDir;
    public Texture2D[] FirstLightMapLight;
    //public Texture2D[] FirstLightMapSM;
    public Texture2D[] SecondLightMapDir;
    public Texture2D[] SecondLightMapLight;
    //public Texture2D[] SecondLightMapSM;

    //public Texture2D[] SceneBLightMapDir;
    //public Texture2D[] SceneBLightMapLight;
    //public Texture2D[] SceneBLightMapSM;

    public LightmapData[] _firstLightMaps;
    public LightmapData[] _secondLightMaps;
    //public LightmapData[] _sceneBLightMaps;

    // Use this for initialization
    void Start () {

        /*if (FirstLightMapDir.Length != FirstLightMapLight.Length || FirstLightMapDir.Length != FirstLightMapSM.Length || SecondLightMapDir.Length != SecondLightMapLight.Length || SecondLightMapDir.Length != SecondLightMapSM.Length)
        {
            Debug.Log("In order for LightMapSwitcher to work, the Near and Far LightMap lists must be of equal length");
            return;
        }*/

        if (FirstLightMapDir.Length != FirstLightMapLight.Length || SecondLightMapDir.Length != SecondLightMapLight.Length)
        {
            Debug.Log("In order for LightMapSwitcher to work, the Near and Far LightMap lists must be of equal length");
            return;
        }
        _firstLightMaps = ConfigureFirstLightmap();
        _secondLightMaps = ConfigureSecondLightmap();
        //_sceneBLightMaps = ConfigureSceneBLightmap();
    }

    LightmapData[] ConfigureFirstLightmap()
    {
        FirstLightMapDir = FirstLightMapDir.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        FirstLightMapLight = FirstLightMapLight.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        //FirstLightMapSM = FirstLightMapSM.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();

        _firstLightMaps = new LightmapData[FirstLightMapDir.Length];
        for (int i = 0; i < FirstLightMapDir.Length; i++)
        {
            _firstLightMaps[i] = new LightmapData();
            _firstLightMaps[i].lightmapDir = FirstLightMapDir[i];
            _firstLightMaps[i].lightmapColor = FirstLightMapLight[i];
            //_firstLightMaps[i].shadowMask = FirstLightMapSM[i];
        }
        return _firstLightMaps;
    }

    LightmapData[] ConfigureSecondLightmap()
    {
        SecondLightMapDir = SecondLightMapDir.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        SecondLightMapLight = SecondLightMapLight.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        //SecondLightMapSM = SecondLightMapSM.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();

        _secondLightMaps = new LightmapData[SecondLightMapDir.Length];
        for (int i = 0; i < SecondLightMapDir.Length; i++)
        {
            _secondLightMaps[i] = new LightmapData();
            _secondLightMaps[i].lightmapDir = SecondLightMapDir[i];
            _secondLightMaps[i].lightmapColor = SecondLightMapLight[i];
            //_secondLightMaps[i].shadowMask = SecondLightMapSM[i];
        }
        return _secondLightMaps;
    }

    /*LightmapData[] ConfigureSceneBLightmap()
    {
        SceneBLightMapDir = SceneBLightMapDir.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        SceneBLightMapLight = SceneBLightMapLight.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();
        //SceneBLightMapSM = SceneBLightMapSM.OrderBy(t2d => t2d.name, new NaturalSortComparer<string>()).ToArray();

        _sceneBLightMaps = new LightmapData[SceneBLightMapDir.Length];
        for (int i = 0; i < SceneBLightMapDir.Length; i++)
        {
            _sceneBLightMaps[i] = new LightmapData();
            _sceneBLightMaps[i].lightmapDir = SceneBLightMapDir[i];
            _sceneBLightMaps[i].lightmapColor = SceneBLightMapLight[i];
            //_sceneBLightMaps[i].shadowMask = SceneBLightMapSM[i];
        }
        return _sceneBLightMaps;
    }*/
}
