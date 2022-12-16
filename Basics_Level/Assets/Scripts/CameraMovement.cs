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
            cameraPos.x = cameraPos.x - 40;
            Camera.main.transform.position = cameraPos;
        }

        //At the right edge
        if(1.0 < pos.x) {
            cameraPos.x = cameraPos.x + 40;
            Camera.main.transform.position = cameraPos;
        }

        //At bottom edge
        if(pos.y < 0) {
            cameraPos.y = cameraPos.y - 8;
            Camera.main.transform.position = cameraPos;
        };

        //At top edge
        if(0.9 < pos.y) {
            cameraPos.y = cameraPos.y + 8;
            Camera.main.transform.position = cameraPos;
        };
    }
}
