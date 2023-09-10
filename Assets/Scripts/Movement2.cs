using UnityEngine;

public class Movement2 : MonoBehaviour
{
    private CharacterController controller;
    private Rigidbody rb;
    private Transform cameraTransform; // Referencia a la c�mara

    public float moveSpeed = 5.0f;
    public float sprintSpeed = 10.0f; // Velocidad al correr
    public float jumpForce = 5.0f;
    public float gravity = -9.8f;
    private Vector3 velocity;

    private bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float staminaMax = 100.0f; // Stamina m�xima
    public float staminaRegenRate = 10.0f; // Tasa de regeneraci�n de stamina por segundo
    private float currentStamina; // Stamina actual

    private bool isJumping = false; // Estado de salto

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        currentStamina = staminaMax; // Inicializa la stamina al m�ximo

        // Obtiene la referencia a la c�mara
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Verificar si el personaje est� en el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
            isJumping = false; // El personaje est� nuevamente en el suelo
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Obtiene la direcci�n hacia la que apunta la c�mara
        Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = cameraForward * verticalInput + cameraTransform.right * horizontalInput;

        float currentMoveSpeed = moveSpeed;

        // Verifica si se est� presionando la tecla de sprint (Shift) y hay suficiente stamina
        if (Input.GetKey(KeyCode.LeftShift) && currentStamina > 0)
        {
            currentMoveSpeed = sprintSpeed;
            // Reduce la stamina mientras se est� corriendo
            currentStamina -= Time.deltaTime * staminaRegenRate;
        }
        else
        {
            // Regenera la stamina si no se est� corriendo
            currentStamina += Time.deltaTime * staminaRegenRate;
        }

        // Limita la stamina dentro de los l�mites
        currentStamina = Mathf.Clamp(currentStamina, 0, staminaMax);

        controller.Move(move * currentMoveSpeed * Time.deltaTime);

        // Salto al presionar la barra espaciadora y estando en el suelo
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity);
            isJumping = true; // El personaje est� en estado de salto
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}