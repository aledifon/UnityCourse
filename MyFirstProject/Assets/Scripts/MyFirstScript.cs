using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    public Vector3 posObject;
    public Vector3 scaleObject;
    public float xPos;

    // Awake is called before the Start method
    private void Awake()
    {
        Debug.Log("Awake");
    }

    // Start is called before the first frame update
    void Start()
    {
        // GET -> Get the value of the x-position.
        xPos = transform.position.x;
        Debug.Log("The position in x of the object on X is: " + xPos);        
        
        //SET -> Setting the value
        transform.position = posObject;
        //GET
        Debug.Log("The position of the object is: " + transform.position);

        transform.localScale = scaleObject;

        transform.Translate(0,0, 0);

        //Debug.Log("Start");

        
    }

    // Update is called once per frame (DeltaTime != Cte)
    void Update()
    {
        //Debug.Log("Update");
        //Debug.Log("Time Update: " + Time.deltaTime);
    }

    // Update is called once per frame (DeltaTime == Cte. Def. values = 0.02s)
    void FixedUpdate()
    {
        //Debug.Log("FixedUpdate time :" + Time.deltaTime);
    }
}
