using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Basics")]
    public AudioSource music;
    public bool startPlaying;
    public BeatScroller beatScroller;
    public static GameManager instance;

    [Header("Score")]
    public int currentScore;
    public int scorePerNote = 100;
    public Text scoreText;

    [Header("Multiplier")]
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;
    public Text mulitplierText;

    void Start()
    {
        currentMultiplier = 1;
        scoreText.text = "Score: 0";
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

        if(currentMultiplier -1 < multiplierThresholds.Length)
        {
           multiplierTracker++;
            if(multiplierThresholds[currentMultiplier -1]<=multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            } 
        }     

        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        mulitplierText.text = "Multiplier: x" + currentMultiplier;
    }

    public void NoteMissed()
    {
        Debug.Log("missed");
        
        currentMultiplier = 1;
        multiplierTracker = 0;
        mulitplierText.text = "Multiplier: x" + currentMultiplier;
    }
}
