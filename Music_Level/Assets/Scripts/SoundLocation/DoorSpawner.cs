using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawner : MonoBehaviour
{
    public GameObject doorPrefab;
    public GameObject endDoorPrefab;
    GameObject player;
    List<Vector3> doorSpawns;
    int totalDoors = 20;

    void Start()
    {   
        player = GameObject.Find("Player");
        doorSpawns = new List<Vector3>();

        for(int i = 0; i < totalDoors; i++){
            Vector3 randomSpawn = new Vector3(Random.Range(-19,20), 3/2, Random.Range(-15,6));
            doorSpawns.Add(randomSpawn);
        }
        SpawnDoor();
    }

    void SpawnDoor()
    {
        List<Vector3> spawnedDoors = new List<Vector3>();
        List<Vector3> notSpawnedDoors = new List<Vector3>();

        foreach (Vector3 spawn in doorSpawns)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-19,20), 3/2, Random.Range(-15,6));
            if (spawn != spawnPosition) //also check for player position
            {
                var newDoor = Instantiate(doorPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, Random.Range(-70, 70), 0)));
                newDoor.transform.parent = gameObject.transform; 
                spawnedDoors.Add(spawn);
            }
            else
            {
                notSpawnedDoors.Add(spawn);
            }
        }
        Vector3 endSpawnPosition = new Vector3(Random.Range(-19,20), 3/2, Random.Range(-15,6));
        var newEndDoor = Instantiate(endDoorPrefab, endSpawnPosition, Quaternion.Euler(new Vector3(0, Random.Range(-70, 70), 0)));
        newEndDoor.transform.parent = gameObject.transform; 

        Debug.Log("spawned" + spawnedDoors.Count);
        Debug.Log("not spawned" + notSpawnedDoors.Count);
    }
}
