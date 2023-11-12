using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public SpriteRenderer ButtonSprite;
    public AudioSource audioSource;
    public AudioClip buttonSound;
    private bool onButton = false;
    
    void OnMouseOver()
    {
        if (!onButton)
        {
            audioSource.PlayOneShot(buttonSound);
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
