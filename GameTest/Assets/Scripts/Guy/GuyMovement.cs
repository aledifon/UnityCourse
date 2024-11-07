using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{
    public float speed,
                turnSpeed;

    private float horizontal,
                vertical;   

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // my anim var points to the Animator component whose GO has this script
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        Move();    
        Turn();
        Animating();
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
    void Animating()
    {
        //if (vertical != 0) // The Character is moving       
        //    anim.SetBool("IsMoving",true);
        //else              // The Character is not moving       
        //    anim.SetBool("IsMoving",false);

        anim.SetBool("IsMoving", (vertical != 0));
    }
}
