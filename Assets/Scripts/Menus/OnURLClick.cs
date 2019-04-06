using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnURLClick : MonoBehaviour {

    public string URL;

    public void GoUrl()
    {
        Application.OpenURL(URL);
    }
	
}
