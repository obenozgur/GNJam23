using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonController : ButtonController
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("DevScene", LoadSceneMode.Single);
    }
}
