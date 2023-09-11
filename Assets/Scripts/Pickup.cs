using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Pickup : MonoBehaviour
{
    [FormerlySerializedAs("rigi")] [SerializeField] private Rigidbody _rigi;
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private Transform player;
    [SerializeField] private float _randomNumber = default;
    [SerializeField] private GameObject _theObjecttoPickup = default;
    
    
    [SerializeField] private float _pickupRange = default;
    [FormerlySerializedAs("_throwForce")] [SerializeField] private float _throwForceUp = default;
    [SerializeField] private float _throwForceForward = default;

    [SerializeField] private bool _isHolding = default;
    [SerializeField] private bool _slotFull = default;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (!_isHolding)
        {
            _rigi.isKinematic = false;
            _sphereCollider.isTrigger = false;
            _slotFull = false;
        }
        else if (_isHolding)
        {
            _rigi.isKinematic = true;
            _sphereCollider.isTrigger = true;
            _slotFull = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    private void LateUpdate()
    {
        Vector3 distanceToPlayer = player.position - _rigi.transform.position;
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_isHolding && distanceToPlayer.magnitude <= _pickupRange && !_slotFull)
            {
                pickup();
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
        _sphereCollider.isTrigger = true;
        Destroy(_theObjecttoPickup);
    }
    
    private void drop()
    {
        _isHolding = false;
        _rigi.isKinematic = false;
        _sphereCollider.isTrigger = false;
        _rigi.velocity = player.GetComponent<Rigidbody>().velocity;
        _rigi.AddForce(_rigi.transform.forward * _throwForceForward, ForceMode.Impulse);
        _rigi.AddForce(_rigi.transform.up * _throwForceUp, ForceMode.Impulse);
        _randomNumber = Random.Range(-1f, 1f);
        _rigi.AddTorque(new Vector3(_randomNumber, _randomNumber, _randomNumber), ForceMode.Impulse);
        
    }
    
}
