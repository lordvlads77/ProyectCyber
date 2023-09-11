using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public Transform character;
    public float rotationSpeed = 2.0f;
    public float distance = 5.0f;
    public float minDistance = 2.0f;
    public float collisionOffset = 0.2f;

    [Header("Canvas Ref")]
    [SerializeField]
    public Canvas _dialogCanvass = default;

    private float mouseX, mouseY;
    private float currentDistance;

    private void Start()
    {
        if (_dialogCanvass == enabled)
        {
            Cursor.lockState = CursorLockMode.None; // Muestra el mouse
            rotationSpeed = 0;
        }
        currentDistance = distance;
    }

    private void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35f, 60f);
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -currentDistance);
        Vector3 desiredPosition = target.position + (rotation * negDistance);
        Ray ray = new Ray(target.position, desiredPosition - target.position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, currentDistance))
        {
            currentDistance = Mathf.Lerp(currentDistance, Mathf.Clamp(hit.distance - collisionOffset, minDistance, distance), Time.deltaTime * 10.0f);
        }
        else
        {
            currentDistance = distance;
        }
        transform.position = target.position + (rotation * new Vector3(0.0f, 0.0f, -currentDistance));

        transform.LookAt(target);

        character.LookAt(transform.position);
    }
}