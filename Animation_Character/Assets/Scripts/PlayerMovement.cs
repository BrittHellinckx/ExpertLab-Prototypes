using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    Vector3 velocity;
    float gravity = -9.81f;
    int speed;

    //Abilities
    int regularSpeed;
    int sprintSpeed;
    int jumpBoost;

    //Animation
    Animator animator;
    Vector3 lastPosition;


    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        //Abilities
        regularSpeed = gameObject.GetComponent<Abilities>().regularSpeed;
        sprintSpeed = gameObject.GetComponent<Abilities>().sprintSpeed;
        jumpBoost = gameObject.GetComponent<Abilities>().jumpBoost;

        //Animation
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("Walk", false);
        animator.SetBool("Stand", true);
        lastPosition = gameObject.transform.position;
    }

    void Update()
    {
        //Check if player is moving
        if(lastPosition == gameObject.transform.position){
            animator.SetBool("Walk", false);
            animator.SetBool("Stand", true);
        }else{
            animator.SetBool("Walk", true);
            animator.SetBool("Stand", false);
        }
        lastPosition = gameObject.transform.position;

        //Player actions
        if(cc.isGrounded){           
            //Jump
            if(Input.GetButton("Jump")){
               velocity.y = Mathf.Sqrt(jumpBoost * -2f * gravity);
                animator.SetBool("Jump", true);
            }else{
            animator.SetBool("Jump", false);
            }
            //Sprint
            if(Input.GetButton("Fire3")){
                speed = sprintSpeed;
                animator.SetBool("Sprint", true);
            }
            else{
                speed = regularSpeed;
                animator.SetBool("Sprint", false);
            }
            //Crouch
            if(Input.GetButton("Fire1"))
                animator.SetBool("Crouch", true);
            else
                animator.SetBool("Crouch", false);         
        }

        //Move Player
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        cc.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        
        velocity.y += gravity * Time.deltaTime;
        cc.Move(velocity * Time.deltaTime);
        }
}
