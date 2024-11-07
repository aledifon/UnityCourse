using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    public float rayLength;
    public LayerMask rayMask; // The layer to be detected by the raycast

    private Ray ray; // var. where I'm going to use the ray information
    private RaycastHit hit; // Here is stored the hit's info between the raycast and the GO (Collider)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;  // towards the charactes's vision

        //Launch the ray 
        // returns true if the ray hits again any GO | Otherwise returns false
        if (Physics.Raycast(ray, out hit, rayLength, rayMask))
        {
            Debug.Log("I'm touching something " + hit.collider.name);
            Debug.Log("Impact point: " + hit.point);
            Debug.Log("Distance: " + hit.distance);
            hit.collider.GetComponent<Rigidbody>().AddForce(Vector3.up*300);
        }
        Debug.DrawRay(ray.origin,ray.direction * rayLength, Color.red);
    }
}
