using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    int health = 20;
    public Slider healthSlider;
    public Transform player;
    void Start()
    {
        healthSlider = GetComponentInChildren<Slider>();
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    void Update(){
        healthSlider.value = health;
        if(health <=0) 
            Destroy(gameObject);
            //Change to death anim
    }

    public void TakeDamage(int damage){
        health -= damage;
        //Alert enemy to attack player
        GetComponent<EnemyAttack>().player = player;
        GetComponent<EnemyAttack>().AttackPlayer();
    }
}
