﻿#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    TextMeshProUGUI scoreText = default;
    [SerializeField]
    TextMeshProUGUI timeText = default;

    static int ScoreMax => 99999;

    static int score;
    static float time;
    static float StartTime => 10;
    static bool clear;
    static bool gameover;

    private void Awake()
    {
        score = 0;
        time = StartTime;

        clear = false;
        gameover = false;
        Item.ClearCount();

        Instance = this;
        ClearScore();
    }

    void Start()
    {
        TinyAudio.PlaySE(TinyAudio.SE.Start);
    }

    void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        if (time <= 0)
        {
            time = 0;
            ToGameover();
        }
        UpdateTimeText();

#if DEBUG_KEY
        if(Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            AddPoint(12345);
        }
#endif
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"{score:00000}";
        }
    }

    void UpdateTimeText()
    {
        timeText.text = $"{time:0.0}";
    }

    public static void AddPoint(int add)
    {
        //score += add;
        //上限チェックその1 手続き型の典型
        //if (score > ScoreMax)
        //{
        //    score = ScoreMax;
        //}
        //上限チェックその2 手続き型の省略形
        //score = score > ScoreMax ? ScoreMax : score;

        //上限チェックその3 関数型で近代的
        score = Mathf.Min(score+add, ScoreMax);

        if (Instance != null)
        {
            Instance.UpdateScoreText();
        }
    }
    
    public static void ClearScore()
    {
        score = 0;
        if (Instance != null)
        {
            Instance.UpdateScoreText();
        }
    }

    public static void ToClear()
    {
        if (clear || gameover) return;

        clear = true;
        SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }

    public static void ToGameover()
    {
        if (clear || gameover) return;
        {
            gameover = true;
            SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
            Time.timeScale = 0f;
        }
    }
}
