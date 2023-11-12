using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : ButtonController
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("TutorialScene", LoadSceneMode.Single);
    }
}
