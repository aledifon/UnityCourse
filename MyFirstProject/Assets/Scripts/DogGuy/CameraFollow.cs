using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // The GO which will be followed by the camera
    public float smoothing;     // Following camera speed (towards the player)

    //public float mouseSensitivity = 1f; // Sensibilidad del ratón
    //private float rotationY = 0f; // Rotación vertical

    Vector3 offset;      // Desired displacement respect to the target

    private void Start()
    {
        //The offset is equal to the camera position less the player position,
        //Is the vector with joins both
        offset = transform.position - player.position;
    }

    //// Start is called before the first frame update
    //void Start()
    //{
    //    if (offset == Vector3.zero)
    //    {
    //        offset = new Vector3(0.66f, 1.19f, -2.91f);
    //    }

    //    //transform.position = player.position + offset;

    //    Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en el centro
    //}

    private void Update()
    {
        //The position which I want to move the camera
        Vector3 camPos = player.position + offset;    
        //Linear interpolation between point A (Starting cam. pos) and point B (New cam. pos.)
        transform.position = Vector3.Lerp(transform.position,camPos,smoothing*Time.deltaTime);
    }

    //private void LateUpdate()
    //{
    //    // Leer el movimiento del ratón
    //    float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
    //    rotationY += mouseX;

    //    // Gets the target movement direction
    //    Vector3 playerDirection = player.forward;

    //    // Updates the camera position
    //    //transform.position = player.position + offset;

    //    // Aplies the rotation to the camera
    //    Quaternion rotation = Quaternion.Euler(0, rotationY, 0);
    //    Vector3 desiredPosition = player.position + rotation * offset; // Ajusta la posición de la cámara
    //    transform.position = desiredPosition;

    //    transform.LookAt(player.position + playerDirection);                       // Makes the camera look to the target
    //}
}
