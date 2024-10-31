using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public GameObject cube;
    public Transform cubeTransform;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cubeTransform);
    }
}
