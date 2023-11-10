using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public SpriteRenderer ButtonSprite;
    private bool onButton = false;
    
    void OnMouseOver()
    {
        if (!onButton)
        {
            ButtonSprite.enabled = true;
            onButton = true;
        }
    }

    void OnMouseExit()
    {
        if (onButton)
        {
            ButtonSprite.enabled = false;
            onButton = false;
        }
    }
}
