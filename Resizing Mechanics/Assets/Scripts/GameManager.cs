using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static event  Action OnGameEnd;

    public static bool IsPlaying {   get; private set; }

    public static void EndGame()
    {
        IsPlaying = false;
        OnGameEnd?.Invoke();
        ChangeTimeScale(0);
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene(0);
    }


    public static void StartGame()
    {
        IsPlaying = true;
        ChangeTimeScale(1);
    }

    public static void ChangeTimeScale(int newTime)
    {
        Time.timeScale = newTime;
    }

}