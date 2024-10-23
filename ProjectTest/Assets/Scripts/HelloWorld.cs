using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    //Variables
    int number = 10,
        numberTwo = 20,
        numberThree;
    // Creamos una variable de tipo string
    string message;
    // Creamos una variable de tipo char
    char letter;
    double numberTen;

    // Start is called before the first frame update
    void Start()
    {
        ExampleWithStrings();
        ExampleWithInts();
    }

    private void ExampleWithStrings()
    {
        message = "Hola Violeta";
        letter = '¬';
        message = message + "Hola"; // A la info que ya estaba guardada previamente añadele un Hola
        message += "Violeta";
        Debug.Log(message);
    }
    private void ExampleWithInts()
    {
        numberTen = 10.2d;
        number = 100;
        numberTwo = number;     // numberTwo = 100
        // Asignando un valor
        // Debug.Log(number)
        Debug.Log(numberTwo);   // 100
        numberTwo = 5;
        Debug.Log(numberTwo);   // 5
        Debug.Log(123 + 4);     // Aqui se suman los 2 valores enteros
        Debug.Log("123" + 4);   // Aqui concatena la cadena de caracteres con el valor numérico.
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}         
}
