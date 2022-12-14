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
        enemyLevelShowing = true;
        enemyLevel.SetActive(true);
        for(int i = 0; i<characters.Count; i++){
            characters[i].transform.position = enemyStartSpawn.position;
        }
        waterfallLevelShowing = false;
        waterfallLevel.SetActive(false);
    } 

    void Update()
    {
        if(enemyLevelShowing)
        {
            enemyLevel.SetActive(true);
            waterfallLevel.SetActive(false);
        }
        else if(waterfallLevelShowing){
            enemyLevel.SetActive(false);
            waterfallLevel.SetActive(true);
        }
    }
    public void SetEnemyLevelSpawn()
    {
        enemyLevelShowing = true;
        waterfallLevelShowing = false;

        cam.transform.position = enemyCameraSpawn.position;
        for(int i = 0; i<characters.Count; i++){
            Debug.Log("change character position to enemy level");
            characters[i].transform.position = enemyEndSpawn.position ; //* Random.Range(-2,2)
        } 
    }
    public void setWaterfallLevelSpawn()
    {
        enemyLevelShowing = false;
        waterfallLevelShowing = true;
        
        cam.transform.position = waterfallCameraSpawn.position;
        for(int i = 0; i<characters.Count; i++){
            
            characters[i].transform.position = waterfallStartSpawn.position;
            Debug.Log(waterfallStartSpawn.position);
            Debug.Log(characters[i].transform.position);

        }
    }
}
