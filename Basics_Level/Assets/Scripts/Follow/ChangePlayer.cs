using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour
{
    ////https://www.youtube.com/watch?v=Q-t0TQF6RAg&t=2s&ab_channel=JTAGames

    [Header("Characters")]
    public Transform character;
    public List<Transform> possibleCharacters;
    int whichCharacter;

    [Header("Switch character")]
    int keyCode;

    [Header("Cooldown")]
    float switchCooldown = 2.0f;
    float currentSwitchCooldown = 0.0f;


    void Start()
    {
        if(character == null && possibleCharacters.Count >=1)
        {
            character = possibleCharacters[0];
        }
        GetComponent<Abilities>().character = character.name;
        Swap(); 
    }

    void Update()
    {
        //Player1
        if(Input.GetKeyDown(KeyCode.Alpha1) && currentSwitchCooldown <= 0)
        {
            keyCode = 0;
            if(character == possibleCharacters[keyCode])
            {
                Debug.Log("Already this character");
            }
            else
            {
                whichCharacter = keyCode;
                currentSwitchCooldown = switchCooldown;
            }
            Swap();
        }
        //Player2
        else if(Input.GetKeyDown(KeyCode.Alpha2) && currentSwitchCooldown <= 0)  
        {
            keyCode = 1;
            if(character == possibleCharacters[keyCode])
            {
                Debug.Log("Already this character");
            }
            else
            {
                whichCharacter = keyCode;
                currentSwitchCooldown = switchCooldown;
            }
            Swap();
        }
        //Player3
        else if(Input.GetKeyDown(KeyCode.Alpha3) && currentSwitchCooldown <= 0)  
        {
            keyCode = 2;
            if(character == possibleCharacters[keyCode])
            {
                Debug.Log("Already this character");
            }
            else
            {
                whichCharacter = keyCode;
                currentSwitchCooldown = switchCooldown;
            }
            Swap();
        }
        //Player4
        else if(Input.GetKeyDown(KeyCode.Alpha4) && currentSwitchCooldown <= 0)  
        {
            keyCode = 3;
            if(character == possibleCharacters[keyCode])
            {
                Debug.Log("Already this character");
            }
            else
            {
                whichCharacter = keyCode;
                currentSwitchCooldown = switchCooldown;
            }
            Swap();
        }
        //Cooldown is full
        else if(currentSwitchCooldown > 0) 
        {
            currentSwitchCooldown -= Time.deltaTime;
        }
    }
    
    void Swap()
    {
        //Player
        character = possibleCharacters[whichCharacter];
        character.GetComponent<PlayerMovement>().enabled = true;
        character.GetComponent<CameraMovement>().enabled = true;
        character.GetComponent<Collider>().enabled = true;

        //Followers
        for(int i = 0; i< possibleCharacters.Count; i++)
        {
            if(possibleCharacters[i]!= character)
            {
                possibleCharacters[i].GetComponent<PlayerMovement>().enabled = false;
                possibleCharacters[i].GetComponent<CameraMovement>().enabled = false;
                possibleCharacters[i].GetComponent<Collider>().enabled = false;
            }
        } 

        //Set character name to activate followers
        GetComponent<FollowPlayer>().player = character;
        GetComponent<FollowPlayer>().followers = possibleCharacters;

        //Set character name to activate abilities
        GetComponent<Abilities>().character = character.name;

        //Set character to enemy to follow
        for( int i = 0; i<5; i++)
        {
            GameObject.Find("Enemies").transform.GetChild(i).GetComponent<EnemyMovement>().player = character;
            GameObject.Find("Enemies").transform.GetChild(i).GetComponent<EnemyHealth>().player = character;         
        }

    }


}
