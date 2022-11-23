using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hack : MonoBehaviour
{
    CharacterController cc;
    Animator animator;
    Vector3 lastPosition;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();   
        lastPosition = gameObject.transform.position;
    }

    void Update()
    {
        //if(cc.isGrounded){           
            //Hack
            if(Input.GetKey(KeyCode.H) && lastPosition == gameObject.transform.position){
                animator.SetBool("Hack", true);
                animator.SetBool("Stand", true);
                animator.SetBool("Walk", false);
            }else if(Input.GetKey(KeyCode.H) && lastPosition != gameObject.transform.position){
                animator.SetBool("Hack", true);
                animator.SetBool("Stand", false);
                animator.SetBool("Walk", true);
            }
            else{
                animator.SetBool("Hack", false);
            }
            lastPosition = gameObject.transform.position;
        //}
    }
}
