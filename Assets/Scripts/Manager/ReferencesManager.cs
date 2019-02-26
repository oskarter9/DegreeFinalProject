using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesManager : MonoBehaviour
{
    public static ReferencesManager instance = null;

    public Light[] POneLights;
    public GameObject POneLightSwitch;
    public GameObject POneControllerContainer;

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
    }

}
