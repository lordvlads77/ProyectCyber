using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    private const float LimiteRotacionX = 80.0f; 
        
    public float mouseSensibilidadX;
    public float mouseSensibilidadY;
    private float rotationX = default;
    [SerializeField] public Canvas _dialogCanvas = default;

    [Header("Referencia")] 
    public Transform cuerpoTransform;
    void Start()
    {
        if (_dialogCanvas == enabled)
        {
            Cursor.lockState = CursorLockMode.None; // Muestra el mouse
            mouseSensibilidadX = 0;
            mouseSensibilidadY = 0;
        }
    }
    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensibilidadX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensibilidadY * Time.deltaTime;

        //Rotacion Arriba  Abajo
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -LimiteRotacionX, LimiteRotacionX); //Limitamos la Rotacion
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        
        // Rotacion izquierda derecha-
        cuerpoTransform.Rotate(Vector3.up * mouseX);
    }
}
