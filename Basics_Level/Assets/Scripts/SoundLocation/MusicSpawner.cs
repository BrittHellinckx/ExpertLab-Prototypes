using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpawner : MonoBehaviour
{
    [Header("Initial Music")]
    public List<GameObject> possibleDoors;
    public GameObject musicPrefab;

    GameObject endDoor;
    GameObject musicSpawned;
    Vector3 musicLocation;

    [Header("New music")]
    GameObject previousMusic;

    void Start()
    {
        endDoor = possibleDoors[Random.Range(0, possibleDoors.Count)];
        musicLocation = endDoor.transform.position;

        musicSpawned = Instantiate(musicPrefab, musicLocation, Quaternion.identity);
        musicSpawned.transform.parent = endDoor.transform;   
    }

    public void RespawnMusic()
    {
        previousMusic = musicSpawned;
        Destroy(previousMusic);

        endDoor = possibleDoors[Random.Range(0, possibleDoors.Count)];
        musicLocation = endDoor.transform.position;
        musicSpawned = Instantiate(musicPrefab, musicLocation, Quaternion.identity);
        musicSpawned.transform.parent = endDoor.transform; 
    }
}
