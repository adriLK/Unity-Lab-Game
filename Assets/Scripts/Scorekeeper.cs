using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] float curTime;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text sceneText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] int level;
    [SerializeField] int balloonsRemaining = 0;

    public const int DEFAULT_POINTS = 1;
    public const int SCORE_THRESHOLD = 10;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if (level == 1) {
            score = 0;
            curTime = 0.0f;
            PersistentData.Instance.SetScore(score);
            PersistentData.Instance.SetTime(curTime);
        } else {
            score = PersistentData.Instance.GetScore();
            curTime = PersistentData.Instance.GetTime();
        }
        DisplayScene();
        DisplayScore();
        DisplayTime();
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        PersistentData.Instance.SetTime(curTime);
        DisplayTime();
    }

    public void AddPoints(int points)
    {
        score += points;
        PersistentData.Instance.SetScore(score);
        DisplayScore();

        //if(score >= SCORE_THRESHOLD)
        //{
        //    SceneManager.LoadScene(level + 2); //level is already 1 less than the index (e.g. 1 instead of 2)
        //}
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
        PersistentData.Instance.SetScore(score);

    }

    private void DisplayScore()
    {
        scoreText.SetText("Score: " + score);
    }

    private void DisplayScene()
    {
        sceneText.SetText("Level: " + level);
    }
    
    private void DisplayTime()
    {
        var ts = TimeSpan.FromSeconds(curTime);
        timeText.SetText("Time: " + string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds));
    }

    public void AddBalloon() {
        balloonsRemaining += 1;
    }

    public void RemoveBalloon() {
        balloonsRemaining -= 1;
        if (balloonsRemaining <= 0) { //if there are no more balloons
            SceneManager.LoadScene(level+1); //load next level
        }
    }
}
