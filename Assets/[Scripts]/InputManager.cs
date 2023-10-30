using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls _playerControls;
    AnimatorController _animatorController;
    [SerializeField] private Vector2 _movementInput;
    [SerializeField] private float _moveAmount;
    [SerializeField] public float _verticalInput;
    [SerializeField] public float _horizontalInput;

    private void Awake()
    {
        _animatorController = GetComponent<AnimatorController>();
    }

    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();
            _playerControls.PlayerMovement.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
        }
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }
    
    private void HandleMovementInput()
    {
        _verticalInput = _movementInput.y;
        _horizontalInput = _movementInput.x;
    }
}
