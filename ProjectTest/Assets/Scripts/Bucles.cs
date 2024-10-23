using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Loops : MonoBehaviour
{
    public int x;
    public List<int> nums;

    // Start is called before the first frame update
    void Start()
    {
        //Show0To100();        
        //Show100To0();
        //Show1ToX();
        ShowPositives();
        //ShowNegatives();
        //ShowPairs();
        //ShowOdds();
        //ShowMultiples3();
        //ShowMultiples2And3();
        //ShowAcumulatedAddition();
    }   
    
    private void Show0To100()
    {
        for (int i = 0; i <= 100; i++)        
            Debug.Log(i);

        // While-loop alternative
        //int j = 0;
        //while (j <= 100)
        //{
        //    Debug.Log(j);
        //    j++;
        //}
    }
    private void Show100To0()
    {
        for (int i = 100; i >= 0; i--)
            Debug.Log(i);

        // While-loop alternative
        //int j = 100;
        //while (j >= 0)
        //{
        //    Debug.Log(j);
        //    j--;
        //}
    }
    private void Show1ToX()
    {
        for (int i = 1; i <= x; i++)
            Debug.Log(i);

        // While-loop alternative
        //int j = 1;
        //while (j <= x)
        //{
        //    Debug.Log(j);
        //    j++;
        //}
    }
    private void ShowPositives()
    {
        foreach (var i in nums)
            if (i > 0) Debug.Log(i);

        // While-loop alternative
        //int j = 0;
        //while (j <= nums.Count-1)
        //{
        //    if (nums[j] > 0)
        //        Debug.Log(nums[j]);
        //    j++;
        //}
    }
    private void ShowNegatives()
    {
        foreach (var i in nums)
            if (i<0) Debug.Log(i);
    }
    private void ShowPairs()
    {
        for (int i = 0; i <= 100; i++)
            if (i%2 == 0) Debug.Log(i);
    }
    private void ShowOdds()
    {
        for (int i = 0; i <= 100; i++)
            if (i%2 != 0) Debug.Log(i);
    }
    private void ShowMultiples3()
    {
        for (int i = 0; i <= 100; i++)
            if (i % 3 == 0) Debug.Log(i);
    }
    private void ShowMultiples2And3()
    {
        for (int i = 0; i <= 100; i++)
            if (i%3 == 0 || i%2 == 0) Debug.Log(i);
    }
    private void ShowAcumulatedAddition()
    {
        int sum=0;
        for (int i = 1; i <= x; i++)        
            sum += i;                                
        Debug.Log(sum);
    }
}
