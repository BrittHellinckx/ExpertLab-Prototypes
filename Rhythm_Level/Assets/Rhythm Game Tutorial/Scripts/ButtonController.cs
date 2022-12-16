using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite notPressedImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            spriteRenderer.sprite = pressedImage;
        }
        if(Input.GetKeyUp(keyToPress))
        {
            spriteRenderer.sprite = notPressedImage;
        }
    }
}
