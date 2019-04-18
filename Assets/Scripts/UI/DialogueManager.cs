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
    private ReferencesManager _referencesManager;

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
        _referencesManager = ReferencesManager.instance;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueOpened = true;
        _referencesManager.LockCursorManager(true);
        _referencesManager.DisablePlayerMovement();
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
        _referencesManager.LockCursorManager(false);
        _referencesManager.EnablePlayerMovement();
        dialogueOpened = false;
        dialogueAC.SetBool("IsOpen", false);
    }
}
