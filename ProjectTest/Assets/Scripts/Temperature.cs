using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    // Class Fields 'Global vars'
    public int celsiusTemp;
    public int farenheitTemp;    

    // Start is called before the first frame update
    void Start()
    {        
        Debug.Log("Celsius to Farenheit conversion");
        //CelsiusToFarenheit();
        Debug.Log("Farenheit to Celsius conversion");
        //FarenheitToCelsius();
    }

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    //private void CelsiusToFarenheit()
    //{
    //    float result;
    //    Debug.Log(celsiusTemp + "�C = " + (1.8f*celsiusTemp+32) + "�F");        
    //}
    //private void FarenheitToCelsius()
    //{
    //    float result;
    //    Debug.Log(farenheitTemp + "�F = " + ((farenheitTemp - 32) / 1.8f) + "�C");        
    //}
}
