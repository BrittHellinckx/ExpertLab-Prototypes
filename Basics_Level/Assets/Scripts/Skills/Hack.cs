using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hack : MonoBehaviour
{
   [Header("Basic Stats")]
    public float regularSpeed;
    public float sprintSpeed;
    public float jumpBoost;

   [Header("Hacking")]
    bool hacking = false;
    float timeBetweenHacking = 3f;
    public ParticleSystem hackParticle;

   [Header("Enemy Detection")]
   public Transform hackPoint;
   float hackRange = 10f;

   [Header("UI")]
   public Text hackDisplay;

////////////////////////////////////////////    

    public void UseHackAbilities()
    {
      ShowDisplay();
      
      if(Input.GetKey(KeyCode.E) && !hacking ) StartCoroutine(Hacking());
      else hackParticle.Stop();
   }
   
   IEnumerator Hacking()
   {
        hacking = true;

        //Hack anim
        hackParticle.Play();

        //Detect enemy
        StartCoroutine(DetectEnemy());

        yield return new WaitForSeconds(timeBetweenHacking);
        hacking = false;
   }
   IEnumerator DetectEnemy()
   {
      Collider[] hits = Physics.OverlapSphere(hackPoint.position, hackRange);
      foreach(Collider hit in hits){
        Debug.Log(hit);
         if(hit.name == "Enemy"){
            GameObject.Find(hit.name).GetComponent<EnemyAttack>().enabled = false;
            GameObject.Find(hit.name).GetComponent<EnemyMovement>().enabled = false;
            yield return new WaitForSeconds(timeBetweenHacking*3);
            GameObject.Find(hit.name).GetComponent<EnemyAttack>().enabled = true;
            GameObject.Find(hit.name).GetComponent<EnemyMovement>().enabled = true;
         }
      }
   }
   void ShowDisplay()
   {
        hackDisplay.text ="text";
   }
}
