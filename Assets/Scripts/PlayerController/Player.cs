using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public void SavePlayer()
    {
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);

        PlayerPrefs.SetInt("CurrentPuzzle", GameManager.instance.currentPuzzle);


    }

    public void LoadPlayer()
    {
        //Player position
        Vector3 position;
        position.x = PlayerPrefs.GetFloat("PlayerX", transform.position.x);
        position.y = PlayerPrefs.GetFloat("PlayerY", transform.position.y);
        position.z = PlayerPrefs.GetFloat("PlayerZ", transform.position.z);
        transform.position = position;

        //Current Puzzle
        GameManager.instance.currentPuzzle = PlayerPrefs.GetInt("CurrentPuzzle");
    }
}
