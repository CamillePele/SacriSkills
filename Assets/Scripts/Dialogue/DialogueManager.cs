using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class DialogueManager : MonoBehaviour
{
    public float letterDelay = 0.1f;
    public AudioClip letterSound;
    public TMP_Text dialogueContainer;
    public UnityEvent onDialogueEnd;
    public string[] dialogues;

    private int currentRound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.clip = letterSound;
        currentRound = 0;
    }

    public void StartDialogue()
    {
        StartCoroutine(Dialogue());
    }

    IEnumerator Dialogue()
    {
        dialogueContainer.text = "";
        foreach (var letter in dialogues[currentRound])
        {
            dialogueContainer.text += letter;
            if(letter != ' ')_audioSource.Play();
            yield return new WaitForSeconds(letterDelay);
        }
        onDialogueEnd.Invoke();
        ++currentRound;
        if (currentRound > dialogues.Length) currentRound = 0;
    }
}
