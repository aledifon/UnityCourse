using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public int speed = 10;
    public int turnspeed = 300;

    float horizontal,
          vertical,
          horizTurn;   

    void Start()
    {

    }

    void Update()
    {
        InputCube();

        // Movement = Direction * Speed
        /*
         * Vector3.forward = (0,0,1) -> Unitary vector (direction)
         * Vector3.backward = (0,0,-1)
         * Vector3.right = (1,0,0) 
         * Vector3.left = (-1,0,0) 
         * Vector3.up = (0,1,0)
         * Vector3.down = (0,-1,0)
         */
        //Time.deltaTime is the time lapsed between updates and by 
        //multiplying it, speed is converted to meters per second

        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);

        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizTurn * turnspeed * Time.deltaTime);        
    }

    // Tell it which keys I'm going to use (keys mapping). 
    void InputCube()
    {
        // A and D (< and >) keys of our keyboard
        horizontal = Input.GetAxis("Horizontal");
        // W and S (up and down) keys of our keyboard
        vertical = Input.GetAxis("Vertical");
        // Mouse X-Axis
        horizTurn = Input.GetAxis("Mouse X");
    }
}