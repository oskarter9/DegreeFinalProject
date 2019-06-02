using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeonTextureSwitch : MonoBehaviour {

    public Texture2D[] EmissiveTextures;

    // Use this for initialization
    void Start () {
        StartCoroutine(IterateTextures());
	}

    public IEnumerator IterateTextures()
    {
        foreach (var texture in EmissiveTextures)
        {
            GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", texture);
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine(IterateTextures());
    }
}
