using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    float bulletForce = 225f;
    
    [Header("Shooting")]
    int magSize, bulletsLeft;
    bool readyToShoot = true, reloading = false;
    float timeBetweenShooting = 2f, reloadTime = 3f;

    public void AttackPlayer()
    {
        transform.LookAt(player);
        
        magSize = 5;
        if(readyToShoot && !reloading && bulletsLeft>0) StartCoroutine(Shooting(magSize));
        if(!reloading && bulletsLeft == 0) StartCoroutine(Reloading(magSize));
    }
    IEnumerator Shooting(int magSize)
    {
        readyToShoot = false;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);
        bullet.GetComponent<BulletEnemy>().player = player;
                
        bulletsLeft--;

        yield return new WaitForSeconds(timeBetweenShooting);
        readyToShoot = true;
    }
    IEnumerator Reloading(int magSize)
    {
        reloading = true;
        bulletsLeft = this.magSize;

        yield return new WaitForSeconds(reloadTime);

        reloading = false;
    }
}
