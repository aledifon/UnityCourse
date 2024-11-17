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

    [Header("Normal Alignment")]
    public float alignmentSpeed = 10f;           // Velocidad de ajuste del personaje
    public float slopeChangeThreshold = 10f;    // Threshold to detect slope variations

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

    private Vector3 normalVector = Vector3.up;      // Terrain normal vector in the current frame
    private Vector3 previousNormal = Vector3.up;    // Terrain normal vector in the previous frame



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

        // VERIF
        //Debug.Log("Is Kinematic: " + rb.isKinematic);
        //Debug.Log("Constraints: " + rb.constraints);
        // VERIF
    }
    private void FixedUpdate()
    {
        LaunchRayCast();            // Detect the ground and the Normal terrain vector

        // Calculate the slope variation
        float angle = Vector3.Angle(previousNormal, normalVector);
        // If the slope change is significative then we'll align the player with the normal terrain
        if (angle > slopeChangeThreshold)
        {
            //AlignToGround();
        }

        if (canPlayerJump)
        {
            canPlayerJump = false;
            // Jump
            Jump();
        }

        // Update the previous normal Vector
        previousNormal = normalVector;
    }

    // Grounding & Normal vector detection
    void LaunchRayCast()
    {
        ray.origin = transform.position + raycastOffset; // Pivot point + offset
        ray.direction = -transform.up; // Downwards

        // I launch a selective raycast, with a specific lenght (rayLength),
        // and will only detect the GOs of the layer rayLayer                
        isGrounded = Physics.Raycast(ray, out hit, rayLength, rayLayer);
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

        if (isGrounded)
        {            
            // Gets & Draws the Normal vector of the terrain
            normalVector = hit.normal;
        }        

        if (normalVector != Vector3.zero)
        {
            Debug.DrawRay(transform.position, normalVector * 2f, Color.green, 1f);
        }
        else
        {
            Debug.LogWarning("La normal del terreno no es válida.");
        }
    }
    //////////////////////////////////////////////////

    // Jumping methods
    void canJump()
    {
        // If I want to jump and I can jump       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            canPlayerJump = true;
    }
    void Jump()
    {
        //rb.AddForce(Vector3.up * jumpForce);
        if ((normalVector != Vector3.zero) &&                // Be sure the normal is updated
            Vector3.Dot(normalVector, Vector3.up) > 0.1f)   // and it has at least 10º of inclination
        {
            // Reset the Rigidbody speeds before jumping
            PrepareForJump();

            // 1. Calculates the force in the normal terrain direction
            Vector3 jumpDirection = normalVector.normalized * jumpForce; // Normalize the normal vector            

            // 2. Adds a little forward force component 
            Vector3 forwardImpulse = transform.forward * (jumpForce / 2f); // Reduced in order to don't be dominant in the jumping

            //Debug.Log("IsGrounded = " + isGrounded);
            //Debug.Log("Velocity: " + rb.velocity);
            //Debug.Log("Angular Velocity: " + rb.angularVelocity);

            Vector3 forceApplied = jumpDirection + forwardImpulse;
            Debug.Log("Force applied = (" + forceApplied.x + " ," + forceApplied.y + " ," + forceApplied.z + " )");

            rb.AddForce(forceApplied);

            rb.useGravity = true; // Reactiva la gravedad después del impulso

            //StartCoroutine(EnableGravityAfterDelay());
        }
    }
    void PrepareForJump()
    {
        rb.velocity = Vector3.zero;          // Resetea velocidad
        rb.angularVelocity = Vector3.zero;  // Resetea rotación
        rb.useGravity = false;              // Opcional: Desactiva la gravedad momentáneamente
    }
    IEnumerator EnableGravityAfterDelay()
    {
        yield return new WaitForSeconds(0.2f); // Espera un pequeño intervalo
        rb.useGravity = true; // Reactiva la gravedad
    }
    //////////////////////////////////////////////////

    // Player with Normal vector Alignment methods
    void AlignToGround()
    {
        // Crear la rotación hacia la nueva normal
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, normalVector) * transform.rotation;

        UnlockRigidBodyConstraints();

        // Interpolar suavemente hacia la rotación objetivo
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * alignmentSpeed);

        // Esperar brevemente antes de bloquear
        StartCoroutine(LockConstraintsAfterDelay(0.1f));        
    }
    void UnlockRigidBodyConstraints()
    {
        // Unlock X and Z rigidbody rotations constraints
        rb.constraints &= ~RigidbodyConstraints.FreezeRotationX;
        rb.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
    }
    IEnumerator LockConstraintsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        LockRigidBodyConstraints();
    }
    void LockRigidBodyConstraints()
    {
        // Lock X and Z Rigidbody rotations constraints
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    //////////////////////////////////////////////////

    // Player's movement
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
        //transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);
        transform.Rotate(transform.up * horizontal * turnSpeed * Time.deltaTime);
    }
    //////////////////////////////////////////////////

    // Player's animation
    void Animating()
    {
        //if (vertical != 0) // The Character is moving       
        //    anim.SetBool("IsMoving",true);
        //else              // The Character is not moving       
        //    anim.SetBool("IsMoving",false);

        anim.SetBool("IsMoving", (vertical != 0));
    }
    //////////////////////////////////////////////////
}
