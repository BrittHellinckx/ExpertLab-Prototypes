using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    Vector3 cameraPos;
    public GameObject player;
    Vector2 screenBounds;
    void Start()
    {
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
            if(SceneManager.GetActiveScene().name =="CombinedScene" && GameObject.Find("LevelManager").GetComponent<LevelManager>().waterfallLevelShowing)
            {
                GameObject.Find("LevelManager").GetComponent<LevelManager>().SetEnemyLevelSpawn();
            }
        }

        //At the right edge
        if(1.0 < pos.x) {
            if(SceneManager.GetActiveScene().name =="CombinedScene" && GameObject.Find("LevelManager").GetComponent<LevelManager>().enemyLevelShowing)
            {
                GameObject.Find("LevelManager").GetComponent<LevelManager>().setWaterfallLevelSpawn();
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
