using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
    PlayerControls _playerControls;
    PlayerLocomotion _playerLocomotion;
    public AnimatorController _animatorController;
    [SerializeField] private Vector2 _movementInput;
    [SerializeField] private Vector2 _cameraInput;
    [SerializeField] public float _cameraInputX;
    [SerializeField] public float _cameraInputY;
    [SerializeField] public float _moveAmount;
    [SerializeField] public float _verticalInput;
    [SerializeField] public float _horizontalInput;
    [FormerlySerializedAs("_squareInput")] [SerializeField] private bool _RightTriggerInput;
    [SerializeField] public bool _inputSquare;

    private void Awake()
    {
        _animatorController = GetComponent<AnimatorController>();
        _playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void OnEnable()
    {
        if (_playerControls == null)
        {
            _playerControls = new PlayerControls();
            _playerControls.PlayerMovement.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            _playerControls.PlayerMovement.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
            
            _playerControls.PlayerActions.Sprinting.performed += i => _RightTriggerInput = true;
            _playerControls.PlayerActions.Sprinting.canceled += i => _RightTriggerInput = false;
            _playerControls.PlayerActions.Pickup.performed += i => _inputSquare = true;
            _playerControls.PlayerActions.Pickup.canceled += i => _inputSquare = false;
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
        HandleSprintingInput();
    }
    
    private void HandleMovementInput()
    {
        _verticalInput = _movementInput.y;
        _horizontalInput = _movementInput.x;
        _cameraInputY = _cameraInput.y;
        _cameraInputX = _cameraInput.x;
        _moveAmount = Mathf.Clamp01(Mathf.Abs(_horizontalInput) + Mathf.Abs(_verticalInput));
        _animatorController.UpdateAnimatorValues(0, _moveAmount, _playerLocomotion._isSprinting);
    }
    
    private void HandleSprintingInput()
    {
        if (_RightTriggerInput && _moveAmount > 0.5f)
        {
            _playerLocomotion._isSprinting = true;
        }
        else
        {
            _playerLocomotion._isSprinting = false;
        }
    }
}
