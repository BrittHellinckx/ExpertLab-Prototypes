using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public int regularSpeed = 2;
    public int sprintSpeed = 3;
    public int jumpBoost = 1;

    string character;

    void Start() 
    {
        character = gameObject.name;

        if(character == "Gun")
        {
            Debug.Log("Gun");
            // CHECK & USE GUN ABILITES
        }
        else if(character == "Melee")
        {
            Debug.Log("Melee");
            // CHECK & USE MELEE ABILITIES
        }
        else if( character == "?")
        {
            Debug.Log("?");
            // CHECK & USE ? ABILITIES
        }
        else if( character == "Hack")
        {
            Debug.Log("Hack");
            // CHECK & USE HACK ABILITIES
        }
    }
}
