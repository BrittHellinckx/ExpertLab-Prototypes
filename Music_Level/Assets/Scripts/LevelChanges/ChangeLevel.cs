using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public List<GameObject> levels;

    [Header("Current song")]
    GameObject currentLevel;
    int index;

    [Header("Switching values")]
    float timeBetweenSwitching = 3.0f;
    bool canSwitch = true;

    [Header("Previous song")]
    GameObject previousLevel;

    void Start()
    {
        for(int i = 0; i<levels.Count; i++)
        {
            levels[i].SetActive(false);
        }
        if(currentLevel == null)
        {
            index = 0;
            currentLevel = levels[index];
            currentLevel.SetActive(true);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canSwitch)
        {
            StartCoroutine(SwitchLevel());
        }else{
            //Debug.Log("not switching");
        }
    }
    IEnumerator SwitchLevel()
    {
        canSwitch = false;
        previousLevel = currentLevel;
        previousLevel.SetActive(false);

        if(index == 2){
            index = 0;
        }else{
            index ++;
        }
        currentLevel = levels[index];
        currentLevel.SetActive(true);

        yield return new WaitForSeconds(timeBetweenSwitching);
        canSwitch = true;
    }
}
