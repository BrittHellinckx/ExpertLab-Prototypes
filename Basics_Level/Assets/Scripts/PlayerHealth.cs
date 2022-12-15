using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int health = 100;
    public Slider healthSlider;
    void Start()
    {
        //healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    void Update(){
        healthSlider.value = health;
        if(health <= 0) 
            Debug.Log("Game OVer");
            //Change to death anim
    }

    public void TakeDamage(int damage){
            health -= damage;
    }
}
