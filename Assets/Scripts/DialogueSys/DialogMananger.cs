using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogMananger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _speakerNameText = default;
    [SerializeField] private TextMeshProUGUI _dialogueTxt = default;
    
    [Header("Animation")]
    [FormerlySerializedAs("anim")] public Animator _anim;
    private readonly int _isOpen = Animator.StringToHash("isOpen");
    
    private Queue<string> _sentences;
    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartCoto(Dialogue dialogue)
    {
        _anim.SetBool(_isOpen, true);
        _speakerNameText.text = dialogue._speakerName;
        _sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }
        showNextSentence();
    }

    public void showNextSentence()
    {
        if (_sentences.Count == 0)
        {
            stopCoto();
            return;
        }
        string sentence = _sentences.Dequeue();
        StopCoroutine(writeSentences(sentence));
        //_dialogueTxt.text = sentence; This call the complete sentence
        StartCoroutine(writeSentences(sentence));
    }

    IEnumerator writeSentences(string sentence)
    {
        _dialogueTxt.text = String.Empty;
        foreach (char letter in sentence.ToCharArray())
        {
            _dialogueTxt.text += letter;
            new WaitForSeconds(2);
            yield return null;
        }
        
    }

    public void stopCoto()
    {
        _anim.SetBool(_isOpen, false);
        Debug.Log("Se acabo el Cotorreo");
    }
}
