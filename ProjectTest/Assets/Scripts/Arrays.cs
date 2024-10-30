using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrays : MonoBehaviour
{
    int[] v1 = new int[5];
    int[] v2 = new int[5];
    int escalar;

    int[] vSum = new int[5];
    int[] vSub = new int[5];
    float[] vProdEscNum = new float[5];
    float vProdEsc = 0.0f;

    float mod;
    float distVectors;
    float angleVectors;

    string v1Str;
    string v2Str;

    // Start is called before the first frame update
    void Start()
    {
        // Init arrays with random values and string messages
        initVectors();

        // Sum Vector        
        vSum = SumVectors(v1, v2);        
        // Substraction Vector
        vSub = SubsVectors(v1,v2);
        // Vector times Escalar Product
        vProdEscNum = ProdEscNum(v1,escalar);
        // Product Vector
        vProdEsc = ProdEscVectors(v1, v2);
        // Module Vector
        mod = ModVector(v1);
        // Distance between vectors
        distVectors = DistVectors(v1,v2);
        // Angle between vectors
        angleVectors = AngleVectors(v1, v2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initVectors()
    {
        // Init arrays with random values
        for (int i = 0; i < v1.Length; i++)
            v1[i] = Random.Range(1, 10);
        for (int i = 0; i < v2.Length; i++)
            v2[i] = Random.Range(1, 10);

        escalar = Random.Range(1, 10);

        // Compound V1 String        
        v1Str = "v1 = (";
        for (int i = 0; i < v1.Length; i++)
        {
            v1Str += v1[i];
            if (i < v1.Length - 1)
                v1Str += ",";
        }
        v1Str += ")";

        // Compound V2 String        
        v2Str = "v2 = (";
        for (int i = 0; i < v2.Length; i++)
        {
            v2Str += v2[i];
            if (i < v2.Length - 1)
                v2Str += ",";
        }
        v2Str += ")";
    }
    public int[] SumVectors(int[] vector1, int[] vector2)
    {
        string result;
        result = "(";

        int[] vSum = new int[vector1.Length];

        for (int i = 0; i < vector1.Length; i++)        
            vSum[i] = vector1[i] + vector2[i];

        for (int i = 0; i < vSum.Length; i++) 
        {            
            result += vSum[i].ToString();
            if (i < vSum.Length-1)
                result += ",";
        }
        result += ")";

        Debug.Log(v1Str + " + " + v2Str + " = " + result);
        return vSum;
    }
    public int[] SubsVectors(int[] vector1, int[] vector2)
    {
        string result;        
        result = "(";

        int[] vSub = new int[vector1.Length];

        for (int i = 0; i < vector1.Length; i++)
            vSub[i] = vector1[i] - vector2[i];

        for (int i = 0; i < vSub.Length; i++)
        {
            result += vSub[i].ToString();
            if (i < vSub.Length - 1)
                result += ",";
        }
        result += ")";        

        Debug.Log(v1Str + " - " + v2Str + " = " + result);
        return vSub;
    }
    public float[] ProdEscNum(int[] vector1, int escalar)
    {
        string result;
        result = "(";

        float[] vProdEscNum = new float[vector1.Length];

        for (int i = 0; i < vector1.Length; i++)
            vProdEscNum[i] = vector1[i] * escalar;

        for (int i = 0; i < vProdEscNum.Length; i++)
        {
            result += vProdEscNum[i].ToString();
            if (i < vProdEscNum.Length - 1)
                result += ",";
        }
        result += ")";

        Debug.Log(v1Str + " * " + escalar + " = " + result);
        return vProdEscNum;
    }
    public float ProdEscVectors(int[] vector1, int[] vector2)
    {        
        float vProdEsc = 0.0f;

        for (int i = 0; i < vector1.Length; i++)
            vProdEsc += vector1[i] * vector2[i];        

        Debug.Log(v1Str + " * " + v2Str + " = " + vProdEsc);
        return vProdEsc;
    }
    public float ModVector(int[] vector1)
    {
        float mod = 0.0f;
        for (int i = 0; i < vector1.Length; i++)
            mod += Mathf.Pow(vector1[i],2);
        mod = Mathf.Sqrt(mod);                        

        Debug.Log("Mod(" + v1Str + ") = " + mod.ToString());
        return mod;
    }
    public float DistVectors(int[] vector1, int[] vector2)
    {
        float mod = 0.0f;
        int[] vSub = SubsVectors(vector1,vector2);

        for (int i = 0; i < vSub.Length; i++)
            mod += Mathf.Pow(vSub[i], 2);
        mod = Mathf.Sqrt(mod);

        Debug.Log("Mod(" + vSub + ") = " + mod.ToString());
        return mod;
    }
    public float AngleVectors(int[] vector1, int[] vector2)
    {
        float result =0.0f;
        float modv1 = ModVector(vector1);
        float modv2 = ModVector(vector2);
        float vProdEsc = ProdEscVectors(vector1,vector2);

        result = Mathf.Acos(vProdEsc/(modv1*modv2));

        Debug.Log("(v1*v2) = " + vProdEsc);
        Debug.Log("Mod(v1) = " + modv1);
        Debug.Log("Mod(v2) = " + modv2);

        Debug.Log("Angle(v1,v2) = " + result.ToString());
        return result;
    }
}
