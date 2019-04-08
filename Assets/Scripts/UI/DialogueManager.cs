using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager instance;

    public TextMeshProUGUI dialogueText;
    public Animator dialogueAC;
    public bool dialogueOpened;

    private Queue<string> _sentences;
    private PlayerLook _cameraRotation;
    private TwinCameraController _swapCamera;

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

    void Start () {
        _sentences = new Queue<string>();
        _cameraRotation = ReferencesManager.instance.Player.GetComponentInChildren<PlayerLook>();
        _swapCamera = ReferencesManager.instance.Player.GetComponentInChildren<TwinCameraController>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueOpened = true;
        LockCursorManager(true);
        dialogueAC.SetBool("IsOpen", true);
        _sentences.Clear();

        foreach (var sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        LockCursorManager(false);
        dialogueOpened = false;
        dialogueAC.SetBool("IsOpen", false);
    }

    void LockCursorManager(bool locked)
    {
        if (locked)
        {
            Cursor.lockState = CursorLockMode.None;
            //_cameraRotation.enabled = false;
            _swapCamera.enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
            //_cameraRotation.enabled = true;
            _swapCamera.enabled = true;
        }
    }
}
