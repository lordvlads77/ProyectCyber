using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMov3D : MonoBehaviour
{
    public float velocidad;
    public float velocidadRotacion;
    public float fuerzaSalto;

    Vector3 movimiento;
    
    [Header("Referencia")]
    public Rigidbody rigi;
    
    
    [Header("CheckGround")]
    public Vector3 checkgroundPosition;
    public bool isGround;
    public float checkGroundRatio;
    public LayerMask checkGroundMask;
    
    [Header("Animation Stuff")]
    [SerializeField] private Animator _animator = default;
    private readonly int _ahSpeed = Animator.StringToHash("speed");

    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal") * velocidad;
        movimiento.z = Input.GetAxisRaw("Vertical") * velocidad;
        movimiento = transform.TransformDirection(movimiento); // Transforma una direccion local en direccion del mundo.

        isGround = Physics.CheckSphere(transform.position + checkgroundPosition, checkGroundRatio, checkGroundMask);
        
        movimiento.y = rigi.velocity.y; // Permite que la gravedad siga funcionando
        rigi.velocity = movimiento; // Aplicamos
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetInteger(_ahSpeed, 2);
            
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            _animator.SetInteger(_ahSpeed, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up * (-velocidadRotacion * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * (velocidadRotacion * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Space) && isGround) // KeyDown y KeyUp no funcionan correctamente en el FixedUpdate
        {
            rigi.AddForce(Vector3.up * fuerzaSalto);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + checkgroundPosition, checkGroundRatio);
    }
}
