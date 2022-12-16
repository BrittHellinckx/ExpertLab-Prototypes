using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        Destroy(gameObject, 5);
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.parent.name == "Enemies") 
        {
            Debug.Log("friendy fire");
            Destroy(gameObject);
            
        }
        else if(collider.name == player.name) 
        {
            if(collider.name == "Melee" && GameObject.Find(collider.name).GetComponent<Melee>().deflecting)
            {
                Destroy(gameObject);
            }else
            {
                Destroy(gameObject);
                GameObject.Find(collider.name).GetComponentInParent<PlayerHealth>().TakeDamage(5);
            }
        }
    }
}
