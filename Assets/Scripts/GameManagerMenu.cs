using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMenu : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseGameUI;
    public bool isGamePaused = false;
    public Player player;
    public AudioSource bgm;

    private void Start()
    {
        bgm.Play();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isGamePaused)
        {
            PauseMenu();
        }
    }

    public void GameOver()
    {
        player.enabled = false;
        isGamePaused = true;
        gameOverUI.SetActive(true);
    }

    public void PauseMenu()
    {
        player.enabled = false;
        isGamePaused = true;
        pauseGameUI.SetActive(true);
    }
    
    public void Resume()
    {
        player.enabled = true;
        isGamePaused = false;
        pauseGameUI.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
