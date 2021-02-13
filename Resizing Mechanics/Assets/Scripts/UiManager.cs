using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Text gameOverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Text scoreText;
    
    

    private void OnEnable()
    {
        GameManager.OnGameEnd += ShowEndScreen;
    }

    private void OnDisable()
    {
        GameManager.OnGameEnd -= ShowEndScreen;
    }

    private void Awake()
    {
        gameOverText.enabled = false;
        restartButton.gameObject.SetActive(false);
        scoreText.enabled = false;
    }

    private void ShowEndScreen()
    {
        gameOverText.enabled = true;
        restartButton.gameObject.SetActive(true);
        scoreText.enabled = false;
    }

    public void RestartButton()
    {
        GameManager.RestartGame();
    }

    public void PlayButton()
    {
        GameManager.StartGame();
        playButton.gameObject.SetActive(false);
        scoreText.enabled = true;
    }

    public void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
