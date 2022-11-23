using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Melee : MonoBehaviour
{
   [Header("Basic Stats")]
   public float regularSpeed;
   public float sprintSpeed;
   public float jumpBoost;

   [Header("Punching")]
   public GameObject arm;
   Vector3 armEuler;
   bool punching = false;
   float timeBetweenPunching = 0.5f;

   [Header("Deflecting")]
   public bool deflecting = false;

   [Header("Enemy Detection")]
   public Transform attackPoint;
   float attackRange = 0.5f;

   [Header("UI")]
   public Text meleeDisplay;

////////////////////////////////////////////

   public void UseMeleeAbilities()
   {
      ShowDisplay();

      armEuler = arm.transform.rotation.eulerAngles;
      armEuler.z = 0;

      if(Input.GetKey(KeyCode.E) && !punching && !deflecting) StartCoroutine(Punching(armEuler));
      else arm.transform.rotation = Quaternion.Euler(armEuler);
   }
   
   IEnumerator Punching(Vector3 armEuler)
   {
      punching = true;
      deflecting = true;

      //Punch movement
      armEuler.z = -50;
      arm.transform.rotation = Quaternion.Euler(armEuler);
      
      //Check if enemy nearby
      DetectEnemy();

      yield return new WaitForSeconds(timeBetweenPunching);
      punching = false;
      deflecting = false;
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
      meleeDisplay.text ="\u221E";
   }
   }