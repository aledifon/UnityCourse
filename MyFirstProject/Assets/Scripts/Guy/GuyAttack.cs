using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GuyAttack : MonoBehaviour
{
    public GameObject ballPrefab;   // Makes ref to a ball prefab, Never an GO of the Scene!
    public Transform posBall;

    public float thrustY,
                thrustZ;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("CreateBalls", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateBalls();
        }
    }
    private void CreateBalls()
    {
        GameObject cloneBall = Instantiate(ballPrefab, posBall.position, posBall.rotation);
        Rigidbody rbBall = cloneBall.GetComponent<Rigidbody>();

        ////vector3.up makes ref. to the global y-axis, from the Scene
        //rbBall.AddForce(Vector3.up * thrustY);
        ////transform.forward makes ref to the local z-axis, from posRot
        //rbBall.AddForce(transform.forward * thrustZ);

        //Force calculation
        Vector3 forceUpward = Vector3.up * thrustY;
        Vector3 forceForward = transform.forward * thrustZ;
        Vector3 forceRes = forceForward + forceUpward; 

        //vector3.up makes ref. to the global y-axis, from the Scene
        rbBall.AddForce(forceRes);        

        Destroy(cloneBall, 2);
    }
}
