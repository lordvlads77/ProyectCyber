using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] public Dialogue dialogue;
    [SerializeField] private GameObject _startCanvas = default;


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogMananger>().StartCoto(dialogue);
        Time.timeScale = 1;
        _startCanvas.SetActive(false);
        
    }
}
