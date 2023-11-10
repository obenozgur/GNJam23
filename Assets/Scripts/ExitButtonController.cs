using System;
using UnityEngine;

public class ExitButtonController : ButtonController
{
    private void OnMouseDown()
    {
        Application.Quit();
    }
}