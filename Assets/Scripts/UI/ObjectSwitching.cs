using System.Collections;
using UnityEngine;

public class ObjectSwitching : MonoBehaviour {

    public int SelectedObject = 0;


	// Use this for initialization
	void Start () {
        if(transform.childCount > 0)
        {
            SelectObject();
        }
	}
	
	// Update is called once per frame
	void Update () {

        int previousSelectedObject = SelectedObject;

		if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(SelectedObject >= transform.childCount - 1)
            {
                SelectedObject = 0;
            }
            else
            {
                SelectedObject++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedObject <= 0)
            {
                SelectedObject = transform.childCount-1;
            }
            else
            {
                SelectedObject--;
            }
        }

        if (previousSelectedObject != SelectedObject)
        {
            SelectObject();
        }

    }

    public void SelectObject()
    {
        int i = 0;
        foreach (Transform playerObject in transform)
        {
            if(i == SelectedObject)
            {
                playerObject.gameObject.SetActive(true);
            }
            else
            {
                playerObject.gameObject.SetActive(false);
            }
            i++;
        }
    }

}
