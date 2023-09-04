using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // El transform del jugador a seguir
    public float rotationSpeed = 2.0f;
    public float distance = 5.0f; // Distancia entre la c�mara y el jugador

    private float mouseX, mouseY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro de la pantalla
    }

    private void Update()
    {
        // Captura la entrada del mouse para girar la c�mara
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35f, 60f); // Limita el �ngulo de la c�mara en vertical

        // Calcula la posici�n de la c�mara en funci�n de la rotaci�n y la distancia
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 desiredPosition = target.position + (rotation * negDistance);

        // Actualiza la posici�n y mira hacia el jugador
        transform.rotation = rotation;
        transform.position = desiredPosition;

        // Hace que la c�mara mire al jugador
        transform.LookAt(target);
    }
}