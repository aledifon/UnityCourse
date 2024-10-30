using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Fibonacci : MonoBehaviour
{
    public int fibonacciPosition;
    int result;

    // Start is called before the first frame update
    //void Start()
    //{
    //    int result = FibonacciNumber(fibonacciPosition);
    //    if (result != -1)
    //    {
    //        Debug.Log("The corresponding fibonnaci number is " + result);
    //    }
    //    else
    //        Debug.Log("Please enter a valid position");
    //}

    //// Update is called once per frame
    void Update()
    {
        result = FibonacciNumber(fibonacciPosition);
        if (result != -1)
        {
            Debug.Log("The " + fibonacciPosition + " position corresponds with the fibonnaci number " + result);
        }
        else
            Debug.Log("Please enter a valid position");
    }

    private int FibonacciNumber(int fibonacciPosition)
    {
        // Fibonacci series
        // 1,1,2,3,5,8,13,21,34,55,89,144,233

        int num1 = 0;
        int num2 = 1;
        int sum = 0;
        
        if (fibonacciPosition > 0)
        {
            for (int i = 1; i <= fibonacciPosition; i++)
            {
                sum = num1 + num2;      // Calculates the next fibonnacci number 
                num1 = num2;            // Updates the current fibonacci position
                num2 = sum;             // Updates the next fibonacci position
            }
            return num1;                // Returns the current fibonacci position
        }        
        else
            return -1;
    }
}
