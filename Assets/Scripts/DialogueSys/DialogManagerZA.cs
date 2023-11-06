using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DialogManagerZA : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _speakerNameText = default;
    [SerializeField] private TextMeshProUGUI _dialogueTxt = default;
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private PlayerMoveManager _playerMoveManager;
    
    [Header("Animation")]
    public Animator _anim;
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
        //StopCoroutine(writeSentences(sentence));
        _dialogueTxt.text = sentence; //This call the complete sentence
        //StartCoroutine(writeSentences(sentence));
    }

    IEnumerator writeSentences(string sentence)
    {
        _dialogueTxt.text = String.Empty;
        foreach (char letter in sentence.ToCharArray())
        {
            _dialogueTxt.text += letter;
            yield return null;
        }
        
    }

    public void stopCoto()
    {
        _anim.SetBool(_isOpen, false);
        Debug.Log("Se acabo el Cotorreo");
        //_camaraControl._dialogCanvas.enabled = false;
        _cameraManager._canvasDialog.enabled = false;
        // En el editor, si presionas ESC, vuelve a aparecer el mouse.
        Cursor.lockState = CursorLockMode.Locked; // Oculta el mouse y lo mantiene dentro del juego
        _cameraManager.cameraPivotSpeed = 2;
        _cameraManager.cameraLookSpeed = 2;
        _inputManager.enabled = true;
        _playerMoveManager.enabled = true;
    }
}
