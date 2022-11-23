using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    ////https://www.youtube.com/watch?v=Q-t0TQF6RAg&t=2s&ab_channel=JTAGames

    public Transform character;
    private Vector3 characterPosition;
    public List<Transform> possibleCharacters;
    public int whichCharacter;
    public int keyCode;


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
        ////Get previous character position
        characterPosition = character.position;
        ////Get other character
        character = possibleCharacters[whichCharacter];
        ////Set new character position as previous character
        character.position = characterPosition;

////SHORTER? .SetActive(false) -> kan niet met transform
        ////Character can move
        character.GetComponent<PlayerMovement>().enabled = true;
        ////Show character
        character.GetComponent<Renderer>().enabled = true;
        ////Collider on character
        character.GetComponent<Collider>().enabled = true;
        ////Controller on character
        character.GetComponent<CharacterController>().enabled = true;

        //Other
        for(int i = 0; i< possibleCharacters.Count; i++)
        {
            if(possibleCharacters[i]!= character)
            {
                ////Other characters can't move
                possibleCharacters[i].GetComponent<PlayerMovement>().enabled = false;
                ////Don't show other characters
                possibleCharacters[i].GetComponent<Renderer>().enabled = false;
                ////No collider on other characters
                possibleCharacters[i].GetComponent<Collider>().enabled = false;
                ////No controller on other characters
                possibleCharacters[i].GetComponent<CharacterController>().enabled = false;
                
            }
        } 
    }
}
