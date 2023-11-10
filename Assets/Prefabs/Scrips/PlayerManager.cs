using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenuScreen;
    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;
    public AudioSource sound_death;
    private void Awake()
    {
        isGameOver = false;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(numberOfCoins);
        coinsText.text = ""+ numberOfCoins.ToString();
        
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ResetNumberOfCoin()
    {
        numberOfCoins = 0;
    }
    public void ReplayGame()
    {
        ResetNumberOfCoin();
        //distanceTraveled = 0f;
        //UpdateUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenuScreen.SetActive(false);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    
}
