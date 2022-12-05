using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false); 
                GameManager.instance.NoteHit();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Activator")
        {
            canBePressed = false;
            if(gameObject.active){
                GameManager.instance.NoteMissed();
            }   
        }
    }
}
