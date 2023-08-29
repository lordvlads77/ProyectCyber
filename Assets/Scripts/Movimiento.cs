using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float megamoveSpeed = 2f;
    public float Resistence = 10f;

    private CharacterController controller;
    private bool isRunning = false;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Cambiar entre correr y caminar
        isRunning = Input.GetKey(KeyCode.LeftShift);

        // Aplicar velocidad de movimiento
        float currentSpeed = isRunning ? moveSpeed * megamoveSpeed : moveSpeed;
        controller.Move(movement * currentSpeed * Time.deltaTime);
    }

}
