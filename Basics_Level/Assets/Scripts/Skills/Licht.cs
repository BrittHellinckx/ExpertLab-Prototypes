using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Licht : MonoBehaviour
{
   [Header("Basic Stats")]
   CharacterController cc;    
   public float regularSpeed;
   public float sprintSpeed;
   public float jumpBoost;   
    
   [Header("Dashing")]
   public ParticleSystem lightParticle; 
   int totalDashes = 3, dashesLeft = 3; 
   bool dashing = false, reloading = false;
   float lightSpeed = 15f, timeBetweenLight = 0.75f, reloadTime = 2f;

   [Header("Enemy Detection")]
   public Transform attackPoint;
   float attackRange = 0.5f;

   [Header("UI")]
   public Text lightDisplay;

////////////////////////////////////////////
   
   public void UseLightAbilities()
   {
      ShowDisplay();

      cc = gameObject.GetComponent<CharacterController>();

      if(Input.GetKey(KeyCode.E) && !dashing && dashesLeft!=0 ) StartCoroutine(Dashing());
      else if(Input.GetKeyDown(KeyCode.R) && dashesLeft < totalDashes && !reloading) StartCoroutine(Reloading());
      else if (!dashing && !reloading && dashesLeft <= 0) StartCoroutine(Reloading());
   }

   IEnumerator Dashing()
   {
        dashing = true;

        //light anim
        lightParticle.Play();
        
        //Dash
        Vector3 move = transform.position + (transform.forward * lightSpeed * 1);
        cc.Move(move * Time.deltaTime);
        Debug.Log(move);

        //Detect enemy
        DetectEnemy();

        //ui
        dashesLeft --;

        yield return new WaitForSeconds(timeBetweenLight);
        dashing = false;
   }

   IEnumerator Reloading()
    {   
        lightParticle.Stop();

        reloading = true;
        dashesLeft = totalDashes;

        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }

    void DetectEnemy()
   {
      Collider[] hits = Physics.OverlapSphere(attackPoint.position, attackRange);
      foreach(Collider hit in hits){
         if(hit.name == "Enemy"){
            GameObject.Find(hit.name).GetComponent<EnemyHealth>().TakeDamage(5);
         }
      }
   }
   
   void ShowDisplay()
   {
      if(dashesLeft <= 0 || reloading){    
        lightDisplay.text = "Reloading ...";
      }else{
        lightDisplay.text = dashesLeft + " / " + totalDashes;
      }
   }
   
}
