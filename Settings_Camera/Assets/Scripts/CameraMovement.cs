using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector2 screenBounds;
    private Vector3 cameraPos;

    void Start()
    {
        cameraPos = Camera.main.transform.position;
        
        //https://learn.unity.com/tutorial/camera-cinemachine?projectId=5c6166dbedbc2a0021b1bc7c#
        Camera.main.orthographic = true;
    }

    void Update()
    {
        //https://forum.unity.com/threads/how-to-detect-screen-edge-in-unity.109583/
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        //At the left edge
        if(pos.x < 0.0) {
            cameraPos.x = cameraPos.x - 17; //Othrograpic = false -> 11 / Othrograpic = true -> 17
            Camera.main.transform.position = cameraPos;
        }

        //At the right edge
        if(1.0 < pos.x) {
            cameraPos.x = cameraPos.x + 17; //Othrograpic = false -> 11 / Othrograpic = true -> 17
            Camera.main.transform.position = cameraPos;
        }

        //At bottom edge
        if(pos.y < 0) {
            cameraPos.y = cameraPos.y - 8; //Othrograpic = false -> 5 / Othrograpic = true -> 8
            Camera.main.transform.position = cameraPos;
        };

        //At top edge
        if(0.9 < pos.y) {
            cameraPos.y = cameraPos.y + 8; //Othrograpic = false -> 5 / Othrograpic = true -> 8
            Camera.main.transform.position = cameraPos;
        };
    }
}
