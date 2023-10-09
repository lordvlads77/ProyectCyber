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
    
    [Header("Camera Ref")]
    [FormerlySerializedAs("_cameraControl")] [SerializeField] private CamaraControl _camaraControl = default;

    public DialogueTriggerZonaB _dialogTriggerZonaB;

    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!_isHolding && distanceToPlayer.magnitude <= _pickupRange && !_slotFull)
            {
                pickup();
                _camaraControl._dialogCanvas.enabled = true;
                _dialogTriggerZonaB.JumpStartDialogue();
                Cursor.lockState = CursorLockMode.None; // Muestra el mouse
                _camaraControl.mouseSensibilidadY = 0;
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
