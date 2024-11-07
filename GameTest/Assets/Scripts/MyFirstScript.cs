using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    public Vector3 posObject;
    public Vector3 scaleObject;
    public float xPos;
    //Class variable (or private field) called light
    Light _light;

    // Awake is called before the Start method
    private void Awake()
    {
        //Debug.Log("Awake");
        //Initialize the Component to modify
        _light = GetComponent<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // GET -> Get the value of the x-position.
        xPos = transform.position.x;

        //Here calls the _light var to use it
        _light.color = Color.red;
        _light.enabled = false;
        _light.range = 50;

        Debug.Log("The position in x of the object on X is: " + xPos);        
        
        //SET -> Setting the value
        transform.position = posObject;
        //GET
        Debug.Log("The position of the object is: " + transform.position);

        transform.localScale = scaleObject;

        transform.Translate(0,0, 0);

        //Debug.Log("Start");

        //gameObject.SetActive(false);
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
