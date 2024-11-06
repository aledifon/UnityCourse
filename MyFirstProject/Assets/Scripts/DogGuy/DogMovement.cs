using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{
    public float speed,
                turnSpeed;

    private float horizontal,
                vertical;   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        Move();    
        Turn();
    }

    void InputPlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void Move()
    {
        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);        
    }
    void Turn()
    {
        transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);
    }
}
