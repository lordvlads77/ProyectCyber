using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{
    InputManager _inputManager;
    CameraManager _cameraManager;
    PlayerLocomotion _playerLocomotion;
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _cameraManager = FindObjectOfType<CameraManager>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        _inputManager.HandleAllInputs();
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
