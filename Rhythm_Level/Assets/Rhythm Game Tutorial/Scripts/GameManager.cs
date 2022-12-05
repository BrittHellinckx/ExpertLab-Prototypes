using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public bool startPlaying;
    public BeatScroller beatScroller;

    public static GameManager instance;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroller.hasStarted = true;
                music.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("hit on time");
    }

    public void NoteMissed()
    {
        Debug.Log("missed");
    }
}
