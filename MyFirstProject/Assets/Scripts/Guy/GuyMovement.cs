using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public float turnSpeed;

    [Header("RayCast")]
    public float rayLength;         // Ray Length
    public float rayNormalLength;   // Ray Normal Length
    public LayerMask rayLayer;      // The GO's layer the raycast will detect.    

    [Header("Jump")]
    public float jumpForce;

    private float horizontal,
                vertical;   

    private Animator anim;
    private Ray ray;
    private RaycastHit hit;     // Gives me the info between the raycast and the GO    
    private bool isGrounded,    // This var will tell me if the player is touching or not the ground
                canPlayerJump;
    private Rigidbody rb;

    // Offset added to the raycast origint to assure the raycast will touch the floor 
    private Vector3 raycastOffset = new Vector3(0f, 0.1f, 0f);

    Vector3 normalVector;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // my anim var points to the Animator component whose GO has this script
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPlayer();
        Move();    
        Turn();
        Animating();   
        
        canJump();      // Manages the player's jump
    }
    private void FixedUpdate()
    {        
        LaunchRayCast();
        if (canPlayerJump)
        {
            canPlayerJump = false;
            // Jump
            Jump();
        }
    }
    void LaunchRayCast()
    {
        ray.origin = transform.position + raycastOffset; // Pivot point + offset
        ray.direction = -transform.up; // Downwards

        // I launch a selective raycast, with a specific lenght (rayLength),
        // and will only detect the GOs of the layer rayLayer
        //if (Physics.Raycast(ray, out hit, rayLength, rayLayer))
        //{
        //    Debug.Log("I'm touching the floor");
        //    // Here I can jump
        //    isGrounded = true;
        //}
        //else     
        //    isGrounded= false;          

        isGrounded = Physics.Raycast(ray, out hit, rayLength, rayLayer);
        Debug.DrawRay(ray.origin, ray.direction * rayLength,Color.red);

        if (isGrounded)
        {
            //Debug.Log("I'm touching the floor");

            // Gets & Draws the Normal vector of the terrain
            normalVector = hit.normal;            

            // (Optional) Rotates the object to alignt it with the normal
            //transform.rotation = Quaternion.FromToRotation(Vector3.up, normalVector);   +
            Debug.Log("Normal vector on plane is = (" + normalVector.x + "," +
                                            normalVector.y + "," +
                                            normalVector.z + ")");
            //Debug.DrawRay(hit.point, normalVector * rayNormalLength, Color.green);
        }
        else
        {
            Debug.Log("Normal vector jumping is = (" + normalVector.x + "," +
                                            normalVector.y + "," +
                                            normalVector.z + ")");
            //Debug.DrawRay(hit.point, normalVector * rayNormalLength, Color.red);
        }
                
    }
    void canJump()
    {
        // If I want to jump and I can jump       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)        
            canPlayerJump = true;                                  
    }
    void Jump() 
    {
        //rb.AddForce(Vector3.up * jumpForce);
        if (normalVector != Vector3.zero)            // Be sure the normal is updated
        {
            //Vector3 jumpDirection = normalVector;   // Guarda la normal en una variable local
            Vector3 jumpDirection = normalVector.normalized; // Normaliza el vector de la normal
            rb.useGravity = false;                  // Disable temporary the gravity during the jump
            rb.AddForce(jumpDirection * jumpForce);
            StartCoroutine(EnableGravityAfterDelay());
        }
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
    IEnumerator EnableGravityAfterDelay()
    {
        yield return new WaitForSeconds(0.1f); // Espera un pequeño intervalo
        rb.useGravity = true; // Reactiva la gravedad
    }
}
