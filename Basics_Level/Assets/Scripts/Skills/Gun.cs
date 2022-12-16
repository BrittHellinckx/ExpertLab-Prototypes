using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Basic Stats")]
    public float regularSpeed;
    public float sprintSpeed;
    public float jumpBoost;
    
    [Header("Shooting")]
    bool readyToShoot = true, reloading = false;

    [Header("Guns")]
    public List<GameObject> weapons;
    GameObject activeWeapon;
    int indexWeapon;
    bool canChangeWeapon = true;

    [Header("GunProperties")]
    int magSize;
    public int damageDone;
    float bulletForce, timeBetweenShooting, reloadTime;
    Transform activeSpawn;
    public List<Transform> activeSpawns;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    int bulletsLeft;
    
    [Header("UI")]
    public Text ammunitionDisplay;

////////////////////////////////////////////
    public void UseGunAbilities()
    {
        //Set weapon to gun at start
        if (activeWeapon == null)
        {
            indexWeapon = 0;  
        }
        
        //Switch weapon
        if(Input.GetKeyDown(KeyCode.F) && canChangeWeapon && readyToShoot && !reloading)
        {
             StartCoroutine(ChangingWeapon());
        }

        //Hide all weapons
        foreach(GameObject weapon in weapons){
            weapon.SetActive(false);
        }

        //Check for active gun in weapons
        CheckWeapon();

        //Show amunition
        ShowDisplay();
    }
    void CheckWeapon(){
        activeWeapon = weapons[indexWeapon];
        activeWeapon.SetActive(true);
        
        if(activeWeapon.name == "Pistol"){
            SetPistol();
        }else if(activeWeapon.name == "Shotgun"){
            SetShotgun();
        }else if (activeWeapon.name == "Rifle"){
            SetRifle();
        }
        
        ShootGun();
    }
    void ShootGun()
    {
        //Shooting
        if(Input.GetKeyDown(KeyCode.E) && readyToShoot && !reloading && bulletsLeft != 0) StartCoroutine(Shooting());
        //Reloading
        else if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading) StartCoroutine(Reloading());
        //Reload automatically when no bullets left
        else if (readyToShoot && !reloading && bulletsLeft <= 0 || bulletsLeft > magSize) StartCoroutine(Reloading());    
    }
    void ShowDisplay()
    { 
        if(bulletsLeft <= 0 || reloading){
            ammunitionDisplay.text = "Reloading ...";
        }else {
            ammunitionDisplay.text = bulletsLeft + " / " + magSize;
        }
    }
    
   ////////
    void SetPistol(){
        magSize = 10;
        damageDone = 1;
        bulletForce = 250f;
        timeBetweenShooting = 0.25f;
        reloadTime = 1f;
        activeSpawn = activeSpawns[0];
    }
    void SetShotgun(){
        magSize = 6;
        damageDone = 3;
        bulletForce = 150f; //Change with radius
        timeBetweenShooting = 0.35f;
        reloadTime = 1.5f;
        activeSpawn = activeSpawns[1];
    }
    void SetRifle(){
        magSize = 40;
        damageDone = 2;
        bulletForce = 350f; 
        timeBetweenShooting = 0.15f;
        reloadTime = 0.5f;
        activeSpawn = activeSpawns[2];
    }
   ///////
    IEnumerator Shooting()
    {
        readyToShoot = false;
        canChangeWeapon = false;

        GameObject bullet = Instantiate(bulletPrefab, activeSpawn.position, activeSpawn.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletForce);
                
        bulletsLeft--;

        yield return new WaitForSeconds(timeBetweenShooting);
        readyToShoot = true;
        canChangeWeapon = true;
    }
    IEnumerator Reloading()
    {
        reloading = true;
        canChangeWeapon = false;
        bulletsLeft = magSize;

        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        canChangeWeapon = true;
    }
    IEnumerator ChangingWeapon()
    {
        canChangeWeapon = false;
        if(indexWeapon == 2){
            indexWeapon = 0;
        }else {
            indexWeapon +=1;
        }

        yield return new WaitForSeconds(3);
        canChangeWeapon = true;
    }   
}
