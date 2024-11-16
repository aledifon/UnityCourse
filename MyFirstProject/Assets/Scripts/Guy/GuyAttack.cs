using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GuyAttack : MonoBehaviour
{
    private Animator anim;
    public Collider colliderAttack;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // my anim var points to the Animator component whose GO has this script
        //collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }
    void Attack()
    {
        //Executes the animation
        anim.SetTrigger("Attack");        
    }

    // Animation Events
    void EnableCollider()
    {
        // Enabling the component
        colliderAttack.enabled = true;
    }
    void DisableCollider()
    {
        // Disabling the component
        colliderAttack.enabled = false;
    }
}
