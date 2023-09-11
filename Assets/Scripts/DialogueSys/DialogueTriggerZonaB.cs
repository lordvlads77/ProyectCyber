using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerZonaB : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    public void JumpStartDialogue()
    {
        FindObjectOfType<DialogueManagerZonaB>().StartCoto(dialogue);
    }
}
