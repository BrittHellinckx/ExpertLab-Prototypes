using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public GameObject logPrefab;
    public bool musicPlaying;
    public Transform spawn;
    bool canSpawnLog = true;
    public float timeBetweenLogs; // wordt beat 

    Vector3 spawnLeft;
    Vector3 spawnRight;
    bool switchSpawn = true;
    void Start()
    {
        //SPAWNS
        spawn = gameObject.transform;
        spawnLeft = new Vector3(spawn.position.x +1,spawn.position.y,spawn.position.z);
        spawnRight= new Vector3(spawn.position.x -1,spawn.position.y,spawn.position.z);

        //AUDIO
        musicPlaying = false;		
        timeBetweenLogs = 98/60f; // Replace with automatic beat detection
    }

    void Update()
    {
       if(musicPlaying &&canSpawnLog)
        {
           StartCoroutine(SpawningLog());
        } 
    }
    IEnumerator SpawningLog()
    {
        canSpawnLog = false;
        if(switchSpawn){
            switchSpawn = false;
            GameObject log = Instantiate(logPrefab, spawnLeft, spawn.rotation);
            log.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 150f);
        }else{
            switchSpawn = true;
            GameObject log = Instantiate(logPrefab, spawnRight, spawn.rotation);
            log.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * 150f);
        }

        yield return new WaitForSeconds(timeBetweenLogs); 
        canSpawnLog = true;
    }
}
