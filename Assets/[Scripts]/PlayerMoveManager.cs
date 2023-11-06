using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{
    InputManager _inputManager;
    CameraManager _cameraManager;
    PlayerLocomotion _playerLocomotion;
    [SerializeField] public Canvas _diagCanvas;
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _cameraManager = FindObjectOfType<CameraManager>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        _inputManager.HandleAllInputs();
        if (_diagCanvas.enabled == true)
        {
            _inputManager.enabled = false;
        }
        else if (_diagCanvas.enabled == false)
        {
            _inputManager.enabled = true;
        }
    }

    private void FixedUpdate()
    {
        _playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
        _cameraManager.HandleAllCameraMovement();
    }
}
