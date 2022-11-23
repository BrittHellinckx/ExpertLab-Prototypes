using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    ////https://www.youtube.com/watch?v=Q-t0TQF6RAg&t=2s&ab_channel=JTAGames

    public Transform character;
    public List<Transform> possibleCharacters;
    int whichCharacter;
    int keyCode;


    void Start()
    {
        if(character == null && possibleCharacters.Count >=1)
        {
            character = possibleCharacters[0];
        }
        Swap();
    }

    
    void Update()
    {
        //Player1
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            keyCode = 0;
            if(character == possibleCharacters[keyCode])
            {
                Debug.Log("Already this character");
            }
            else
            {
                whichCharacter = keyCode;
            }
            Swap();
        }

        //Player2
        if(Input.GetKeyDown(KeyCode.Alpha2))  
        {
            keyCode = 1;
            if(character == possibleCharacters[keyCode])
            {
                Debug.Log("Already this character");
            }
            else
            {
                whichCharacter = keyCode;
            }
            Swap();
        }
        //Player3
        if(Input.GetKeyDown(KeyCode.Alpha3))  
        {
            keyCode = 2;
            if(character == possibleCharacters[keyCode])
            {
                Debug.Log("Already this character");
            }
            else
            {
                whichCharacter = keyCode;
            }
            Swap();
        }
        //Player4
        if(Input.GetKeyDown(KeyCode.Alpha4))  
        {
            keyCode = 3;
            if(character == possibleCharacters[keyCode])
            {
                Debug.Log("Already this character");
            }
            else
            {
                whichCharacter = keyCode;
            }
            Swap();
        }
    }
    void Swap()
    {
        //Player
        character = possibleCharacters[whichCharacter];
        character.GetComponent<PlayerMovement>().enabled = true;
        //character.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        //Followers
        for(int i = 0; i< possibleCharacters.Count; i++)
        {
            if(possibleCharacters[i]!= character)
            {
                possibleCharacters[i].GetComponent<PlayerMovement>().enabled = false;
                //possibleCharacters[i].GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
            }
        } 
        GetComponent<FollowPlayer>().player = character;
        GetComponent<FollowPlayer>().followers = possibleCharacters;
    }
}
