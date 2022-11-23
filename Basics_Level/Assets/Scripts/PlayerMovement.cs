using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    Vector3 moveDirection = Vector3.zero;
    float speed;

    [Header("Charcter specific")]
    float regularSpeed;
    float sprintSpeed;
    float jumpBoost;

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        regularSpeed = GetComponentInParent<Abilities>().regularSpeed;
        sprintSpeed = GetComponentInParent<Abilities>().sprintSpeed;
        jumpBoost = GetComponentInParent<Abilities>().jumpBoost;
        
    }

    void Update()
    {
        if(cc.isGrounded){           
            //Jump
            if(Input.GetButton("Jump")){
               playerVelocity.y = Mathf.Sqrt(jumpBoost * -2f * gravityValue);
            }
            //Sprint
            if(Input.GetButton("Fire3"))
                speed = sprintSpeed;
            else
                speed = regularSpeed;
            //Crouch
            if(Input.GetButton("Fire1")){
                //Crouch
            }
        }
        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        cc.Move(move * Time.deltaTime * speed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        cc.Move(playerVelocity * Time.deltaTime);
        }
}
