using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    Vector3 moveDirection = Vector3.zero;
    public bool canMove =true;
    float speed;
    [Header("reset")]
    public List<Transform> characters;
    List<Vector3> startPositions = new List<Vector3>();

    [Header("Charcter specific")]
    float regularSpeed;
    float sprintSpeed;
    float jumpBoost;

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();

        //Set characters start position
        characters = gameObject.GetComponentInParent<ChangePlayer>().possibleCharacters;
        for(int i = 0; i< characters.Count; i++)
        {
            startPositions.Add(characters[i].transform.position);
        }  

        //Set characters speed/ jump abilities
        regularSpeed = GetComponentInParent<Abilities>().regularSpeed;
        sprintSpeed = GetComponentInParent<Abilities>().sprintSpeed;
        jumpBoost = GetComponentInParent<Abilities>().jumpBoost;
        
    }

    void Update()
    {
        if(canMove)
        {
            MovePlayer();
        }
    }
    void MovePlayer()
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

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Respawn")
        {
            GetComponentInParent<PlayerHealth>().TakeDamage(15);
            for(int i = 0; i< characters.Count; i++)
            {
                cc.enabled = false;
                characters[i].transform.position = startPositions[i];
                cc.enabled = true;
            } 
        }
        if(collider.tag == "Previous")
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().SetEnemyLevelSpawn();
        }
        if(collider.tag == "Next")
        {
            GameObject.Find("LevelManager").GetComponent<LevelManager>().setWaterfallLevelSpawn();
        }
        if(collider.tag == "Finish")
        {
            Debug.Log("Reached the end");
        }
        if(collider.tag == "Music")
        {
            //enable music script
        }
    }
}
