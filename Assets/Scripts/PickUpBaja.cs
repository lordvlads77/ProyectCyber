using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PickUpBaja : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigi;
    [FormerlySerializedAs("_boxCollider")] [SerializeField] private SphereCollider _SphereCollider;
    [SerializeField] private Transform player;
    [SerializeField] private float _randomNumber = default;
    [SerializeField] private GameObject _theObjectToPickup = default;
    
    
    [SerializeField] private float _pickupRange = default;
    [FormerlySerializedAs("_throwForce")] [SerializeField] private float _throwForceUp = default;
    [SerializeField] private float _throwForceForward = default;

    [SerializeField] private bool _isHolding = default;
    [SerializeField] private bool _slotFull = default;

    public DialogueTriggerZonaB _dialogTriggerZonaB;
    
    [Header("Input Manager Ref")]
    [SerializeField] private InputManager _inputManager;

    [Header("Camera Control Ref")] 
    [SerializeField] private CameraManager _cameraManager;
    public CollectibleItem _collectibleItem;

    void Start()
    {
        if (_collectibleItem != null)
        {
            string itemName = _collectibleItem.itemName;
        }
        if (!_isHolding)
        {
            _rigi.isKinematic = false;
            _SphereCollider.isTrigger = false;
            _slotFull = false;
        }
        else if (_isHolding)
        {
            _rigi.isKinematic = true;
            _SphereCollider.isTrigger = true;
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
                _dialogTriggerZonaB.JumpStartDialogue();
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
        _SphereCollider.isTrigger = true;
        Destroy(_theObjectToPickup);
        _collectibleItem.IsCollected = true;
    }
    
    private void drop()
    {
        _isHolding = false;
        _rigi.isKinematic = false;
        _SphereCollider.isTrigger = false;
        _rigi.velocity = player.GetComponent<Rigidbody>().velocity;
        _rigi.AddForce(_rigi.transform.forward * _throwForceForward, ForceMode.Impulse);
        _rigi.AddForce(_rigi.transform.up * _throwForceUp, ForceMode.Impulse);
        _randomNumber = Random.Range(-1f, 1f);
        _rigi.AddTorque(new Vector3(_randomNumber, _randomNumber, _randomNumber), ForceMode.Impulse);
        
    }
}
