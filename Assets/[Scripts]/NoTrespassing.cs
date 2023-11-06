using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoTrespassing : MonoBehaviour
{
    [SerializeField] private DialogueTrigger _dialogueTrigger;
    [SerializeField] private CameraManager _cameraManager;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _cameraManager._canvasDialog.enabled = true;
            _dialogueTrigger.NoTrespass();
            Cursor.lockState = CursorLockMode.None;
            
        }
    }
}
