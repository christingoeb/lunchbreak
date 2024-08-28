using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class character : MonoBehaviour
{
    public float speed = 5.0f;              // Bewegungsgeschwindigkeit des Charakters
    public float mouseSensitivity = 2.0f;   // Empfindlichkeit der Mausbewegung
    public float verticalRotationLimit = 80f; // Begrenzung der vertikalen Kamerabewegung

    private CharacterController characterController;
    private float verticalRotation = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Sperrt den Cursor in der Mitte des Bildschirms
    }

    void Update()
    {
        // Bewegung mit Pfeiltasten oder WASD
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontalInput + transform.forward * verticalInput;
        characterController.Move(movement * speed * Time.deltaTime);

        // Mausbewegung für die Kamerasteuerung
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Horizontale Rotation
        transform.Rotate(0, mouseX, 0);

        // Vertikale Rotation
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
