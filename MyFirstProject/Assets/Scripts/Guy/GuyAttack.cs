using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GuyAttack : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    public Collider colliderAttack;    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // my anim var points to the Animator component whose GO has this script
        //collider = GetComponent<Collider>();        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && rb.velocity.y == 0)
        /*(IsPlayingAnimation("Idle_Battle_SwordAndShield") ||
        IsPlayingAnimation("MoveFWD_Battle_InPlace_SwordAndShield"))*/
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
    bool IsPlayingAnimation(string name)
    {
        // Obtén información del estado actual en la capa 0 (por defecto)
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        // Compara el nombre del estado actual con el de la animación deseada
        return stateInfo.IsName(name);
    }
    void DisableCollider()
    {
        // Disabling the component
        colliderAttack.enabled = false;
    }
}
