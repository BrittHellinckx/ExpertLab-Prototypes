using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    private bool triggerActive = false;
    public Text endText;
    public Text instructionText;
    void Start(){
        endText.gameObject.SetActive(false);
        Destroy(instructionText, 2);
    }
 
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
            endText.gameObject.SetActive(true);

        }else{
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(20);
            gameObject.GetComponentInParent<MusicSpawner>().RespawnMusic();
        }
    }
}
