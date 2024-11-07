using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("When we press the left-button mouse");
    }

    private void OnMouseUp()
    {
        Debug.Log("When you release the left-button mouse");
    }

    private void OnMouseEnter()
    {
        Debug.Log("When we have pass over the GO");
    }

    private void OnMouseDrag()
    {
        Debug.Log("When we drag the GO");
    }
}
