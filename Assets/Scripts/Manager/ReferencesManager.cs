using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesManager : MonoBehaviour
{
    public static ReferencesManager instance = null;

    public Transform PlayerObjectsContainer;

    [Header("First Puzzle References")]

    public Light[] POneLights;
    public GameObject POneLightSwitch;
    public GameObject POneControllerContainer;
    public Item POneLighterItem;
    [HideInInspector]
    public LightmapSwitch POneLighmapSwitch;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        POneLighmapSwitch = GetComponentInChildren<LightmapSwitch>();
    }
}
