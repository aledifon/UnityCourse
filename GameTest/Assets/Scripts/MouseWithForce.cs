using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWithForce : MonoBehaviour
{
    // Var declaration
    Rigidbody rb;

    public float thrust;

    // Start is called before the first frame update
    void Awake()
    {
        // Init the var
        // Indicating which rigidbody we are going to use
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {

        rb.AddForce(transform.up * thrust);      
        rb.useGravity = true;
    }
}
