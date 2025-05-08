using Mirror;
using UnityEngine;

public class RobotMovement : NetworkBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float turnSpeed = 200f; // Velocidad de rotaci�n del robot
    public float mouseLookSpeed = 2f; // Velocidad de rotaci�n con el mouse

    public Camera robotCamera; // Referencia a la c�mara del robot

    private float pitch = 0f; // Para rotar la c�mara arriba y abajo

    void Update()
    {
        // Asegurarse de que solo el jugador local pueda controlar su robot
        if (!isLocalPlayer) return;

        Move();
        RotateWithMouse();
    }

    void Move()
    {
        // Movimiento del robot con las teclas W, A, S, D (y I, J, K, L si prefieres)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void RotateWithMouse()
    {
        // Rotaci�n del robot con el mouse
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseLookSpeed;
        transform.Rotate(Vector3.up * horizontalRotation);

        // Rotaci�n de la c�mara hacia arriba y abajo
        pitch -= Input.GetAxis("Mouse Y") * mouseLookSpeed;
        pitch = Mathf.Clamp(pitch, -80f, 80f); // Limitar la rotaci�n vertical
        robotCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}