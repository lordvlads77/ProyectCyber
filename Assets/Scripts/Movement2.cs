using UnityEngine;

public class Movement2 : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    private Transform cameraTransform; // Referencia a la cámara

    public float moveSpeed = 5.0f;
    public float sprintSpeed = 10.0f; // Velocidad al correr
    public float jumpForce = 5.0f;
    public float gravity = -9.8f;
    private Vector3 velocity;

    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float staminaMax = 100.0f; // Stamina máxima
    public float staminaRegenRate = 10.0f; // Tasa de regeneración de stamina por segundo
    private float currentStamina; // Stamina actual

    private bool isJumping = false; // Estado de salto

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        currentStamina = staminaMax; // Inicializa la stamina al máximo

        // Obtiene la referencia a la cámara
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Verificar si el personaje está en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
            isJumping = false; // El personaje está nuevamente en el suelo
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Obtiene la dirección hacia la que apunta la cámara
        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = cameraForward * verticalInput + cameraTransform.right * horizontalInput;

        float currentMoveSpeed = moveSpeed;

        // Verifica si se está presionando la tecla de sprint (Shift) y hay suficiente stamina
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            currentMoveSpeed = sprintSpeed;
            // Reduce la stamina mientras se está corriendo
            currentStamina -= Time.deltaTime * staminaRegenRate;
        }
        else
        {
            // Regenera la stamina si no se está corriendo
            currentStamina += Time.deltaTime * staminaRegenRate;
        }

        // Limita la stamina dentro de los límites
        currentStamina = Mathf.Clamp(currentStamina, 0, staminaMax);

        controller.Move(move * currentMoveSpeed * Time.deltaTime);

        // Salto al presionar la barra espaciadora y estando en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
            isJumping = true; // El personaje está en estado de salto
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}