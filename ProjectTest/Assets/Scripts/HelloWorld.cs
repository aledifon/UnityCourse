using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    //Variables
    int number = 10;        

    // x = 10
    // y = 3
    // z = true

    // log 14


    // Start is called before the first frame update
    void Start()
    {
        //string message = "Hola Violeta";
        //Debug.Log("Mi number is "+ number);

        //float x = 2.0f;
        //x = Mathf.Pow((x + x), 2);
        ////x= Mathf.Sqrt(x+Mathf.Sqrt(x)+5);
        //Debug.Log(x);

        int x, y;
        bool z;

        float t = 2.3f;
        t = t + 3.6f;

        x = 5;
        y = x-2;
        x = y*y+1;
        z = (x>(y+5));
        //Debug.Log( x + y + (z ? 1 : 0));
        Debug.Log(x + y + Convert.ToInt32(z));
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}         
}
