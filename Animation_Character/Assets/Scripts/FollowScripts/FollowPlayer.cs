using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
   //https://docs.unity3d.com/Manual/nav-BuildingNavMesh.html

    public Transform player;
    public List<Transform> followers;
    Vector3 playerPos;

    void Start()
    {    }

    void Update()
    {
        for(int i=0; i<followers.Count; i++){
            if(player.transform.position.x - 3 > followers[i].position.x ||followers[i].position.x> player.transform.position.x + 3) 
            {
                followers[i].GetComponent<Animator>().SetBool("Walk", true);
                followers[i].GetComponent<Animator>().SetBool("Stand", false);
                
                //ERROR - Followers don't move
                followers[i].GetComponent<NavMeshAgent>().isStopped = false;
                followers[i].GetComponent<NavMeshAgent>().destination = player.position;
                //followers[i].rotation = Quaternion.LookRotation(followers[i].GetComponent<NavMeshAgent>().velocity.normalized);
            }
            else if(player.transform.position.z - 3 > followers[i].position.z ||followers[i].position.z > player.transform.position.z + 3)
            {
                followers[i].GetComponent<Animator>().SetBool("Walk", true);
                followers[i].GetComponent<Animator>().SetBool("Stand", false);

                //ERROR - Followers don't move
                followers[i].GetComponent<NavMeshAgent>().isStopped = false;
                followers[i].GetComponent<NavMeshAgent>().destination = player.position;
                //followers[i].rotation = Quaternion.LookRotation(followers[i].GetComponent<NavMeshAgent>().velocity.normalized);
            }
            else
            {
                followers[i].GetComponent<Animator>().SetBool("Walk", false);
                followers[i].GetComponent<Animator>().SetBool("Stand", true);

                //
                followers[i].GetComponent<NavMeshAgent>().isStopped = true;
            }
        }
   }
}
