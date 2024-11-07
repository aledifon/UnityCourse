using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Material mat;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("I colissioned with " + collision.gameObject.name);
        //Check if I'm collisioning against the cube
        //Access to the collider of the GO whose the ball is colliding
        //anch check if its tag is equal to Enemy
        if (collision.collider.CompareTag("Enemy"))
        {
            //Change the cube material
            //Access to its Renderer component and to its Material property
            collision.gameObject.GetComponent<Renderer>().material = mat;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I'm collisionning Trigger with: " + other.name);
        if (other.CompareTag("Enemy"))
        {
            //This other.gameObject is making ref. in this case to the cube
            Destroy(other.gameObject);  
        }
    }
}
