using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMovement : MonoBehaviour
{
    Rigidbody log;
    Transform spawn;
    float speed = 5;
    void Start()
    {
        Destroy(gameObject, 4);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
