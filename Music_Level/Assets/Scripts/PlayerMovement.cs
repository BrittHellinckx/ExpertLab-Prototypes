using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Character global stats")]
	CharacterController cc;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    Vector3 moveDirection = Vector3.zero;

    [Header("Character specific stats")]
    int speed;
    int regularSpeed;
    int sprintSpeed;
    int jumpBoost;

    [Header("Doors")]
    List<GameObject> doors;

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        regularSpeed = 3;
        sprintSpeed = 4;
    }

    void Update()
    {
        if(cc.isGrounded){           
            //Sprint
            if(Input.GetButton("Fire3"))
                speed = sprintSpeed;
            else
                speed = regularSpeed;
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