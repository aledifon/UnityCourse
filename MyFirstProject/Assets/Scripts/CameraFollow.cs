using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    // The GO which will be followed by the camera
    public Vector3 offset;      // Desired displacement respect to the target

    public float mouseSensitivity = 1f; // Sensibilidad del rat�n
    private float rotationY = 0f; // Rotaci�n vertical

    // Start is called before the first frame update
    void Start()
    {
        if (offset == Vector3.zero)
        {
            offset = new Vector3(0.66f, 1.19f, -2.91f);
        }

        //transform.position = target.position + offset;

        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro
    }    

    private void LateUpdate()
    {
        // Leer el movimiento del rat�n
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY += mouseX;

        // Gets the target movement direction
        Vector3 targetDirection = target.forward;

        // Updates the camera position
        //transform.position = target.position + offset;

        // Aplies the rotation to the camera
        Quaternion rotation = Quaternion.Euler(0, rotationY, 0);
        Vector3 desiredPosition = target.position + rotation * offset; // Ajusta la posici�n de la c�mara
        transform.position = desiredPosition;

        transform.LookAt(target.position + targetDirection);                       // Makes the camera look to the target
    }
}
