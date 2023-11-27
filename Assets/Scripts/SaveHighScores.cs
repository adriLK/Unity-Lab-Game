using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SaveHighScores : MonoBehaviour
{
    [SerializeField] float playerTime;
    [SerializeField] int playerScore;
    const string TIME_KEY = "TopScoreTime";
    const string SCORE_KEY = "TopScore";
    const int NUM_HIGH_SCORES = 5;

    [SerializeField] TMP_Text[] timeTexts;
    [SerializeField] TMP_Text[] scoreTexts;

    // Start is called before the first frame update
    void Start()
    {
        playerTime = PersistentData.Instance.GetTime();
        playerScore = PersistentData.Instance.GetScore();

        //playerScore = playerScore + Random.Range(11,21);

        SaveScore();
        ViewScores();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveScore()
    {
        for (int i = 1; i <=  NUM_HIGH_SCORES; i++)
        {
            string currentTimeKey = TIME_KEY + i;
            string currentScoreKey = SCORE_KEY + i;


            //first check if there is a high scoring playe
            if (PlayerPrefs.HasKey(currentScoreKey))
            {
                /* in middle */
                //then check if player's score is greater than existing high score
                int currentScore = PlayerPrefs.GetInt(currentScoreKey);


                if (playerScore > currentScore)
                {
                    int tempScore = currentScore;
                    float tempTime = PlayerPrefs.GetFloat(currentTimeKey);

                    PlayerPrefs.SetInt(currentScoreKey, playerScore);
                    PlayerPrefs.SetFloat(currentTimeKey, playerTime);

                    playerScore = tempScore;
                    playerTime = tempTime;
                }
                
            }
        

            else
            {
                PlayerPrefs.SetInt(currentScoreKey, playerScore);
                PlayerPrefs.SetFloat(currentTimeKey, playerTime);
                return;
            }
        }

    }

    public void ViewScores()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            var ts = TimeSpan.FromSeconds(PlayerPrefs.GetFloat(TIME_KEY+(i+1)));
            //timeTexts[i].SetText(PlayerPrefs.GetFloat(TIME_KEY+(i+1)).ToString());
            timeTexts[i].SetText(string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds));
            scoreTexts[i].SetText(PlayerPrefs.GetInt(SCORE_KEY+(i+1)).ToString());
        }

    }
}
