﻿using System.Collections;
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
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (DialogueManager.instance.dialogueOpened)
            {
                DialogueManager.instance.DisplayNextSentence();
            }
            else
            {
                ReferencesManager.instance.CurrentStoryDialogue.TriggerDialogue();
            }
        }
    }

    private void PlayerMovement()
    {
        float horizInput = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertInput = Input.GetAxis("Vertical") * MovementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);
    }
}
