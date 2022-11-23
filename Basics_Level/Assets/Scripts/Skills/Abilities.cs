using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    public float regularSpeed;
    public float sprintSpeed;
    public float jumpBoost;
    public string character;

    void Start()
    {
        GameObject.Find("Hack").GetComponent<Hack>().hackParticle.Stop();
        GameObject.Find("Light").GetComponent<Licht>().lightParticle.Stop();
    }

    void Update() 
    {
        //CAN TRY: GetComponent(Type.GetType(myString))
        switch(character)
        {
            case "Gun":
                regularSpeed = GetComponentInChildren<Gun>().regularSpeed;
                sprintSpeed = GetComponentInChildren<Gun>().sprintSpeed;
                jumpBoost = GetComponentInChildren<Gun>().jumpBoost;
                GetComponentInChildren<Gun>().UseGunAbilities();
                break;
            case "Melee":
                regularSpeed = GetComponentInChildren<Melee>().regularSpeed;
                sprintSpeed = GetComponentInChildren<Melee>().sprintSpeed;
                jumpBoost = GetComponentInChildren<Melee>().jumpBoost;
                GetComponentInChildren<Melee>().UseMeleeAbilities();
                break;
            case "Light":
                regularSpeed = GetComponentInChildren<Licht>().regularSpeed;
                sprintSpeed = GetComponentInChildren<Licht>().sprintSpeed;
                jumpBoost = GetComponentInChildren<Licht>().jumpBoost;
                GetComponentInChildren<Licht>().UseLightAbilities();
                break;
            case "Hack":
                regularSpeed = GetComponentInChildren<Hack>().regularSpeed;
                sprintSpeed = GetComponentInChildren<Hack>().sprintSpeed;
                jumpBoost = GetComponentInChildren<Hack>().jumpBoost;
                GetComponentInChildren<Hack>().UseHackAbilities();
                break;
        }        
    }
}
