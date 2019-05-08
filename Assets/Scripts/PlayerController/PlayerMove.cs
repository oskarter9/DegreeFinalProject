using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float MovementSpeed;

    private CharacterController charController;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
        PlaySoundStep();
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertInput = Input.GetAxis("Vertical") * MovementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);
    }

    private void PlaySoundStep()
    {
        if(GetComponent<CharacterController>().velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().volume = Random.Range(0.4f, 0.8f);
            GetComponent<AudioSource>().Play();
        }
    }
}
