using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

using System.Linq;
using JetBrains.Annotations;

public class DayWeek : MonoBehaviour
{
    // Field
    public int dayNumber;

    public int num1,num2,num3;
    public int[] nums = new int[3];    
    public List<int> numList = new List<int>();    
       
    public enum SortingType
    {
        Ascending,
        Descending
    }
    public SortingType sortingType = SortingType.Ascending;
    public enum SortingWays
    {
        NoLoops,
        Array,
        Lists,
        LINQ,
    }
    public SortingWays sortingWay = SortingWays.Array;

    // Start is called before the first frame update
    void Start()
    {     
        //WeekSwitch();        
        if (sortingType == SortingType.Ascending)
            SortingAscending();
        else 
            SortingDescending();
    }   

    private void SortingAscending()
    {
        switch (sortingWay)
        {
            case SortingWays.NoLoops:
                SortingNoLoops();
                break;
            case SortingWays.Array:
                SortingArray();
                break;
            case SortingWays.Lists:
                SortingLists();
                break;
            case SortingWays.LINQ:
                SortingLINQ();
                break;
            default:
                break;
        }        
    }
    private void SortingDescending()
    {
        switch (sortingWay)
        {
            case SortingWays.NoLoops:
                SortingNoLoops();
                break;
            case SortingWays.Array:
                SortingArray();
                break;
            case SortingWays.Lists:
                SortingLists();
                break;
            case SortingWays.LINQ:
                SortingLINQ();
                break;
            default:
                break;
        }       
    }
    private void SortingNoLoops()
    {
        int biggestNum = num1;
        int middleNum = num1;
        int smallestNum = num1;

        if (num1 < num2)
        {
            smallestNum = num1;
            biggestNum = num2;
        }
        else
        {
            smallestNum = num2;
            biggestNum = num1;
        }

        if (num3 < smallestNum)
        {
            middleNum = smallestNum;
            smallestNum = num3;
        }
        else
        {
            if (num3 > biggestNum)
            {
                middleNum = biggestNum;
                biggestNum = num3;
            }
            else
            {
                middleNum = num3;
            }
        }

        //if (num2 > num1)                    // (2|3) 1    
        //{
        //    if (num3 > num2)
        //    {
        //        biggestNum = num3;          // 3 2 1
        //        middleNum = num2;
        //        smallestNum = num1;
        //    }
        //    else
        //    {
        //        biggestNum = num2;          // 2 (3|1)
        //        if (num3 > num1)
        //        {
        //            middleNum = num3;       // 2 3 1
        //            smallestNum = num1;
        //        }
        //        else
        //        {
        //            middleNum = num1;       // 2 1 3
        //            smallestNum = num3;
        //        }
        //    }
        //}
        //else if (num3 > num1)               // 3 1 2
        //{
        //    biggestNum = num3;
        //    middleNum = num1;
        //    smallestNum = num2;
        //}
        //else                                // 1 (2|3)
        //{                                   
        //    biggestNum = num1;
        //    if (num3 > num2)
        //    {
        //        middleNum = num3;           // 1 3 3
        //        smallestNum = num2;
        //    }
        //    else
        //    {                
        //        middleNum = num2;           // 1 2 3
        //        smallestNum = num3;                
        //    }
        //}                    

        if (sortingType == SortingType.Ascending)
        {
            Debug.Log(smallestNum + " " + middleNum + " " + biggestNum);
        }
        else
        {            
            Debug.Log(biggestNum + " " + middleNum + " " + smallestNum);            
        }
    }
    private void SortingArray()
    {                   
        if (sortingType == SortingType.Ascending)
        {   
            for (int i = 0; i < nums.Length-1; i++)
            {
                //Debug.Log("i = " + i);
                for (int j = i+1; j < nums.Length; j++)
                {
                    //Debug.Log("j = " + j);
                    if (nums[i] > nums[j])
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }                    
                }                
            }
            foreach (var i in nums)
                Debug.Log(i);
        }
        else
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            foreach (var i in nums)
                Debug.Log(i);
        }
    }
    private void SortingLists()
    {
        if (sortingType == SortingType.Ascending) 
        {
            // Ascending List sorting (Sorting method)
            numList.Sort();
            foreach (int i in numList)
                Debug.Log(i);
        }
        else
        {
            // Descending List sorting (Sorting method & Lambda expression)
            numList.Sort((x, y) => y.CompareTo(x));
            foreach (int i in numList)
                Debug.Log(i);            
        }
    }
    private void SortingLINQ()
    {
        if (sortingType == SortingType.Ascending)
        {
            // Ascending List sorting (LINQ & lambda expression)            
            numList = numList.OrderBy(n => n).ToList();
            foreach (int i in numList)
                Debug.Log(i);
        }
        else
        {            
            numList = numList.OrderByDescending(n => n).ToList();            
            foreach (int i in numList)
                Debug.Log(i);
        }
    }
    private void Week()
    {
        if (dayNumber == 1)
        {
            Debug.Log("Es lunes.");
        }
        else if (dayNumber == 2)
        {
            Debug.Log("Es martes.");
        }
        else if (dayNumber == 3)
        {
            Debug.Log("Es miercoles.");
        }
        else if (dayNumber == 4)
        {
            Debug.Log("Es jueves.");
        }
        else if (dayNumber == 5)
        {
            Debug.Log("Es viernes.");
        }
        else if (dayNumber == 6)
        {
            Debug.Log("Es sabado.");
        }
        else if (dayNumber == 7)
        {
            Debug.Log("Es domingo.");
        }
        else
        {
            Debug.Log("Introduce un valor entre 1 y 7");
        }
    }
    private void WeekSwitch()
    {
        switch (dayNumber)
        {
            case 1:
                Debug.Log("Es lunes.");
                break;
            case 2:
                Debug.Log("Es martes.");
                break;
            case 3:
                Debug.Log("Es miercoles.");
                break;
            case 4:
                Debug.Log("Es jueves.");
                break;
            case 5:
                Debug.Log("Es viernes.");
                break;
            case 6:
                Debug.Log("Es sabado.");
                break;
            case 7:
                Debug.Log("Es domingo.");
                break;
            default:
                Debug.Log("Introduce un valor entre 1 y 7");
                break;
        }
    }
}
