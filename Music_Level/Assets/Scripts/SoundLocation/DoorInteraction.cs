using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    private bool triggerActive = false;
 
    public void OnTriggerEnter(Collider collider)
    { 
        if (collider.name == "Player")//collider.CompareTag("Player") -> May need to use when using multiple characters
        {
            triggerActive = true;
        }
    }
 
    public void OnTriggerExit(Collider collider)
    {
        if (collider.name == "Player")
        {
             triggerActive = false;
        }
    }
 
    void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        if(gameObject.GetComponentInChildren<AudioSource>() != null)
        {
            Debug.Log("Load next level");
            //Load next level -> scenemanager
        }else{
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(20);
            gameObject.GetComponentInParent<MusicSpawner>().RespawnMusic();
        }
    }
}
