using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 cameraPos;
    public GameObject player;
    void Start()
    {
        cameraPos = Camera.main.transform.position;
    }

    void Update()
    {
        cameraPos.x = player.transform.position.x;
        Camera.main.transform.position = cameraPos;
    }
}
