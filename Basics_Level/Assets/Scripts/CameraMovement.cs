using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    Vector3 cameraPos;
    public GameObject player;
    Vector2 screenBounds;
    
    [Header("Level Movement")]
    bool enemyLevelShowing;
    public Transform enemyCameraSpawn;
    bool waterLevelShowing;
    public Transform waterfallCameraSpawn;
    void Start()
    {
        enemyLevelShowing = true;
        waterLevelShowing = false;
        cameraPos = Camera.main.transform.position;
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name =="CombinedScene")
        {
            FixedCamera();
        }
        else if(SceneManager.GetActiveScene().name =="DoorScene")
        {
            FollowCamera();
        }
    }

    void FollowCamera()
    {
        cameraPos.x = player.transform.position.x;
        Camera.main.transform.position = cameraPos;
    }
    void FixedCamera()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //At the left edge
        if(pos.x < 0.0) {
            if(waterLevelShowing){
                enemyLevelShowing = true;
                waterLevelShowing = false;
                cameraPos = enemyCameraSpawn.position;
                Camera.main.transform.position = cameraPos;
            }
        }

        //At the right edge
        if(1.0 < pos.x) {
            if (enemyLevelShowing){
                enemyLevelShowing = false;
                waterLevelShowing = true;
                cameraPos = waterfallCameraSpawn.position;
                Camera.main.transform.position = cameraPos;
            }
        }

        //At bottom edge
        if(pos.y < 0) {
            
        };

        //At top edge
        if(0.9 < pos.y) {
            
        };
    }
}
