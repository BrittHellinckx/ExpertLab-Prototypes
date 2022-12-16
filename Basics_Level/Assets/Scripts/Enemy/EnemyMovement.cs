using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float speed = 0.5f;
    public float obstacleRange = 3.0f;

    void Update(){
        //If Enemy far from player
        if(transform.position.x < player.position.x - 7.5|| transform.position.x > player.position.x + 7.5) MoveEnemy();
        else if(transform.position.z < player.position.z - 7.5 || transform.position.z > player.position.z + 7.5) MoveEnemy();
        
        //If enemy close to player
        else
        {
            transform.Translate(0,0,0);
            GetComponent<EnemyAttack>().player = player;
            GetComponent<EnemyAttack>().AttackPlayer();
        }
    }
    void MoveEnemy(){
        transform.Translate(0,0, speed * Time.deltaTime);
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.SphereCast(ray, 0.75f, out hit)){
            if(hit.distance < obstacleRange){
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    } 
}
