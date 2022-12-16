using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TakeDamage(int damage){
            health -= damage;
    }
}
