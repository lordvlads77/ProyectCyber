using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDialogCaller : MonoBehaviour
{
    public DialogTriggerZA _DialogTriggerZa;
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private PlayerMoveManager _playerMoveManager;
    
    public void Exiting()
    {
        _cameraManager._canvasDialog.enabled = true;
        _DialogTriggerZa.ExitDiag();
        Cursor.lockState = CursorLockMode.None;
        _inputManager._animatorController.UpdateAnimatorValues(0, 0, false);
        _playerMoveManager.enabled = false;
        _inputManager.enabled = false;
    }
}
