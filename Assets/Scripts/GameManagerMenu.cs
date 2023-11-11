using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMenu : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseGameUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void pauseMenu()
    {
        pauseGameUI.SetActive(true);

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }


}
