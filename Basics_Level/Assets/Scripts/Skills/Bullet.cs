using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage;
    void Start()
    {
        Destroy(gameObject, 5);
    }
    void Update()
    {
        damage = GetComponent<Gun>().damageDone;
    }
    void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.parent.name == "Enemies") {
            Destroy(gameObject);
            GameObject.Find(collider.name).GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        else if(collider.transform.parent.name == "Characters") {
            Debug.Log("friendy fire");
            Destroy(gameObject);
        }
    }
}
