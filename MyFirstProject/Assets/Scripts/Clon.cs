using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clon : MonoBehaviour
{
    public GameObject acorn;    
    public Transform posRotAcorn;

    public float thrustY,
                thrustZ;

    // Start is called before the first frame update
    void Start()
    {
        // Calls the Method 'CreateObjectsWithForce' after 2s passed
        //Invoke("CreateObjectsWithForce", 2);
        // Calls the Method 'CreateObjectsWithForce' periodically
        // (After 1s the 1st time, and after 2s from the 2nd time)
        InvokeRepeating("CreateObjectsWithForce", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            CreateObjectsWithForce();            
        }
    }

    private void CreateObjects()
    {
        // Spawn prefab acorn clons
        // Clons are instantiated on (0,0,0) pos by def.
        Instantiate(acorn);
    }

    private void CreateObjectsWithPosition()
    {
        // Spawn prefab acorn clons
        // Clons are instantiated on specific pos.
        Instantiate(acorn,posRotAcorn.position,posRotAcorn.rotation);
    }
    private void CreateObjectsWithForce()
    {        
        GameObject cloneAcorn = Instantiate(acorn, posRotAcorn.position, posRotAcorn.rotation);

        Destroy(cloneAcorn, 2);
        Rigidbody rbAcorn = cloneAcorn.GetComponent<Rigidbody>();
        //vector3.up makes ref. to the global y-axis, from the Scene
        rbAcorn.AddForce(Vector3.up * thrustY);
        //transform.forward makes ref to the local z-axis, from posRot
        rbAcorn.AddForce(transform.forward * thrustZ);
        Invoke("Message", 1.5f);
    }
    
    void Message()
    {
        Debug.Log("I'm going to became a Jedi with Unity");
    }
}
