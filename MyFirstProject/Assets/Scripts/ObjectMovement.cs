using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public int speed;
    public int turnspeed;

    void Start()
    {
        
    }
    
    void Update()
    {
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
        if (Input.GetKey(KeyCode.M))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        //transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * turnspeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Se ha pulsado la tecla P");
        }
    }
}
