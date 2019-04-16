using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVScreenManager : MonoBehaviour {

    public Texture2D[] MorseTranslationTextures;

    [HideInInspector]
    public List<Texture2D> AvailableTextures;

    [HideInInspector]
    public List<Texture2D> AvailableTexturesToAdd;

    private int _secondsBetweenTextures = 3;
    private WaitForSeconds _waitBetweenTextures;

    void Start()
    {
        _waitBetweenTextures = new WaitForSeconds(_secondsBetweenTextures);
        AvailableTextures = new List<Texture2D>();
    }

    public IEnumerator IterateTextures()
    {

        if(AvailableTextures.Count != 0)
        {
            foreach (var texture in AvailableTextures)
            {
                GetComponent<MeshRenderer>().material.SetTexture("_EmissionMap", texture);
                yield return _waitBetweenTextures;
            }
            AddToAvailable(AvailableTexturesToAdd);
            StartCoroutine(IterateTextures());
        }
        yield return null;
    }

    private void AddToAvailable(List<Texture2D> textureList)
    {
        AvailableTextures.AddRange(textureList);
        textureList.Clear();
    }
}
