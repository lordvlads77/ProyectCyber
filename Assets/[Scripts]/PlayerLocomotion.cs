using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLocomotion : MonoBehaviour
{
    [Header("The Input Manager Script")]
    InputManager _inputManager;
    [Header("The Move Direction")]
    public Vector3 _moveDirection;
    [Header("The Camara Transform")]
    Transform cameraObject;
    [Header("Rigidbody Reference")]
    private Rigidbody _elRigido;

    [SerializeField] public bool _isSprinting;
    [Header("Walk Speed")]
    [SerializeField] public float _walkingSpeed = default;
    [FormerlySerializedAs("_movementSpeed")]
    [Header("Running Speed")]
    [SerializeField] public float _runningSpeed = default;
    [Header("Sprinting Speed")] 
    [SerializeField] public float _sprintingSpeed = default;
    [Header("Rotation Speed")]
    [SerializeField] public float _rotationSpeed = default;
    
    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
        _elRigido = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    

    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        _moveDirection = cameraObject.forward * _inputManager._verticalInput;
        _moveDirection = _moveDirection + cameraObject.right * _inputManager._horizontalInput; //Movement Input
        _moveDirection.Normalize();
        _moveDirection.y = 0;
        if (_isSprinting)
        {
            _moveDirection = _moveDirection * _sprintingSpeed;
        }
        else
        {
            if (_inputManager._moveAmount >= 0.5f)
            {
                _moveDirection = _moveDirection * _runningSpeed;
            }
            else
            {
                _moveDirection = _moveDirection * _walkingSpeed;
            }
        }
        // If we are sprinting the sprinting speed will be selected
        // if we are running the running speed will be selected
        // If we are walking the walking speed will be selected
        _moveDirection = _moveDirection * _runningSpeed;
        Vector3 moveVelocity = _moveDirection;
        _elRigido.velocity = moveVelocity;
    }

    private void HandleRotation()
    {
        Vector3 _targetDirection = Vector3.zero;
        _targetDirection = cameraObject.forward * _inputManager._verticalInput;
        _targetDirection = _targetDirection + cameraObject.right * _inputManager._horizontalInput;
        _targetDirection.Normalize();
        _targetDirection.y = 0;
        if (_targetDirection == Vector3.zero)
        {
            _targetDirection = transform.forward;
        }
        Quaternion _targetRotation = Quaternion.LookRotation(_targetDirection);
        Quaternion _playerRotation = Quaternion.Slerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
        
        transform.rotation = _playerRotation;
    }
}
