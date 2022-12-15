using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Waterfall Level")]
    public GameObject waterfallLevel;
    public Transform waterfallStartSpawn;
    public Transform waterfallCameraSpawn;
    public bool waterfallLevelShowing;

    [Header("Enemy Level")]
    
    public GameObject enemyLevel;
    public Transform enemyStartSpawn;
    public Transform enemyEndSpawn;
    public Transform enemyCameraSpawn;
    public bool enemyLevelShowing;

    [Header("Player")]    
    public List<GameObject> characters;
    public Camera cam;
    Vector3 cameraPos;

    void Start()
    {

    } 

    public void SetEnemyLevelSpawn()
    {

        cam.transform.position = enemyCameraSpawn.position;

    }
    public void setWaterfallLevelSpawn()
    {
        

        cam.transform.position = waterfallCameraSpawn.position;

    }
}
