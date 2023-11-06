using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PickupAlta : MonoBehaviour
{
    [FormerlySerializedAs("rigi")] [SerializeField] private Rigidbody _rigi;
    [FormerlySerializedAs("_sphereCollider")] [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private Transform player;
    [SerializeField] private float _randomNumber = default;
    [FormerlySerializedAs("_theObjecttoPickup")] [SerializeField] private GameObject _theObjectToPickup = default;
    
    
    [SerializeField] private float _pickupRange = default;
    [FormerlySerializedAs("_throwForce")] [SerializeField] private float _throwForceUp = default;
    [SerializeField] private float _throwForceForward = default;

    [SerializeField] private bool _isHolding = default;
    [SerializeField] private bool _slotFull = default;
    
    [Header("Camara Ref")]
    [SerializeField] private CameraManager _cameraManager;

    public DialogTriggerZA _dialogTriggerZA;
    [SerializeField] private InputManager _inputManager;

    void Start()
    {
        if (!_isHolding)
        {
            _rigi.isKinematic = false;
            _boxCollider.isTrigger = false;
            _slotFull = false;
        }
        else if (_isHolding)
        {
            _rigi.isKinematic = true;
            _boxCollider.isTrigger = true;
            _slotFull = true;
        }
    }
    

    private void LateUpdate()
    {
        Vector3 distanceToPlayer = player.position - _rigi.transform.position;
        if (_inputManager._inputSquare == true)
        {
            if (!_isHolding && distanceToPlayer.magnitude <= _pickupRange && !_slotFull)
            {
                pickup();
                _cameraManager._canvasDialog.enabled = true;
                _dialogTriggerZA.PickUpDialog();
                Cursor.lockState = CursorLockMode.None; // Muestra el mouse
                _cameraManager.cameraPivotSpeed = 0;
                _cameraManager.cameraLookSpeed = 0;
            }
        }
    }

    /*private void FixedUpdate()
    {
        if (_isHolding && Input.GetKeyDown(KeyCode.Q))
        {
            drop();
        }
    }*/

    private void pickup()
    {
        _isHolding = true;
        _slotFull = true;
        _rigi.isKinematic = true;
        _boxCollider.isTrigger = true;
        Destroy(_theObjectToPickup);
    }
    
    private void drop()
    {
        _isHolding = false;
        _rigi.isKinematic = false;
        _boxCollider.isTrigger = false;
        _rigi.velocity = player.GetComponent<Rigidbody>().velocity;
        _rigi.AddForce(_rigi.transform.forward * _throwForceForward, ForceMode.Impulse);
        _rigi.AddForce(_rigi.transform.up * _throwForceUp, ForceMode.Impulse);
        _randomNumber = Random.Range(-1f, 1f);
        _rigi.AddTorque(new Vector3(_randomNumber, _randomNumber, _randomNumber), ForceMode.Impulse);
        
    }
    
}
