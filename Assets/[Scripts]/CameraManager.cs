using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    private InputManager _inputManager;
    public Transform targetTransform; // The object the camera will follow
    public Transform _cameraPivot; //The object the camera uses to pivot (Look up and down)
    [SerializeField] private Transform _cameraTransform; // The transform of the actual camera objet in the scene
    public LayerMask _collisionLayers; // The layers we want the camera to collide with
    private float _defaultPosition;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    private Vector3 _cameraVectorPosition;
    [SerializeField] private float _cameraCollisionRadius = 0.2f;
    [SerializeField] private float _cameraCollisionOffset = 0.2f; // How much the camera will jump off of objects it colliding with
    [SerializeField] private float _minimumCollisionOffset = 0.2f;
    [SerializeField] private float _timeofTheLerp = 0.2f;
    [FormerlySerializedAs("followSpeed")] public float cameraFollowSpeed = 0.2f;
    [SerializeField] public float cameraLookSpeed = 2f;
    [SerializeField] public float cameraPivotSpeed = 2f;
    public float _lookAngle; //Camera look up and down
    public float _pivotAngle; // Camera look left and right
    [SerializeField] private float _minimunPivotAngle = -35f;
    [SerializeField] private float _maximumPivotAngle = 35f;
    [SerializeField] public Canvas _canvasDialog;

    private void Awake()
    {
        _inputManager = FindObjectOfType<InputManager>();
        targetTransform = FindObjectOfType<PlayerMoveManager>().transform;
        _cameraTransform = Camera.main.transform;
        _defaultPosition = _cameraTransform.localPosition.z;
        _canvasDialog.enabled = false;
    }

    private void Start()
    {
        if (_canvasDialog.enabled == true )
        {
            Cursor.lockState = CursorLockMode.None; // Muestra el mouse
            cameraPivotSpeed = 0;
            cameraLookSpeed = 0;
            
        }
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }
    private void FollowTarget()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);
        transform.position = targetPosition;
    }

    private void RotateCamera()
    {
        Vector3 _rotation;
        Quaternion _targetRotation;
        _lookAngle = _lookAngle + (_inputManager._cameraInputX * cameraLookSpeed);
        _pivotAngle = _pivotAngle - (_inputManager._cameraInputY * cameraPivotSpeed );
        _pivotAngle = Mathf.Clamp(_pivotAngle, _minimunPivotAngle, _maximumPivotAngle);
        _rotation = Vector3.zero;
        _rotation.y = _lookAngle;
        _targetRotation = Quaternion.Euler(_rotation);
        transform.rotation = _targetRotation;
        _rotation = Vector3.zero;
        _rotation.x = _pivotAngle;
        _targetRotation = Quaternion.Euler(_rotation);
        _cameraPivot.localRotation = _targetRotation;
    }
    
    private void HandleCameraCollisions()
    {
        float _targetPosition = _defaultPosition;
        RaycastHit hit;
        Vector3 _direction = _cameraTransform.position - _cameraPivot.position;
        _direction.Normalize();

        if (Physics.SphereCast(_cameraPivot.transform.position, _cameraCollisionRadius, _direction, out hit, Mathf.Abs(_targetPosition), _collisionLayers))
        {
            float _distance = Vector3.Distance(_cameraPivot.position, hit.point);
            _targetPosition =- (_distance - _cameraCollisionOffset);
        }

        if (Mathf.Abs(_targetPosition) < _minimumCollisionOffset)
        {
            _targetPosition = _targetPosition - _minimumCollisionOffset;
        }
        _cameraVectorPosition.z = Mathf.Lerp(_cameraTransform.localPosition.z, _targetPosition, _timeofTheLerp);
        _cameraTransform.localPosition = _cameraVectorPosition;
    }
}
