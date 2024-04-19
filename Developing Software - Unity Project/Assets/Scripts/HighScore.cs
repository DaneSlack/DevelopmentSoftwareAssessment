using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    //Declare Varibles
    [SerializeField]
    TMP_Text messageDisplay;
    [SerializeField]
    TMP_Text playerNameDisplay;
    [SerializeField]
    TMP_Text playerScoreDisplay;
    [SerializeField]
    TMP_Text[] highScoreDisplays;
    [SerializeField]
    TMP_Text[] highScoreNameDisplays;
    [SerializeField]
    bool highScoreAcheived = false;
    [SerializeField]
    int playerScore;
    [SerializeField]
    string playerName;

    void Start()
    {
        //CALL method PrepareData()
        PrepareData();

        //CALL method DisplayData()
        DisplayData();
    }

    public void PrepareData()
    {
        //Declare Varibles
        int newScore;
        string newName;
        int highScore = 0;
        string highScoreName = null;

        //READ playerScore and playerName variables from Unity PlayerPrefs
        int playerScore = PlayerPrefs.GetInt("playerScore");
        string playerName = PlayerPrefs.GetString("playerName");

        //INITIALISE newScore and newName variables to be equal to playerScore and playerName
        newScore = playerScore;
        newName = playerName;

        //FOR scoreIndex from 0 to 2
        for (int scoreIndex = 0; scoreIndex <= 2; scoreIndex++)
        {

            //READ highScore and highScoreName variables from Unity PlayerPrefs using the scoreIndex
            highScore = PlayerPrefs.GetInt("highScore" + scoreIndex);
            highScoreName = PlayerPrefs.GetString("highScoreName" + scoreIndex);

            //IF newScore is greater than highScore THEN
            if (newScore >= highScore)
            {
                //SET highScoreAchieved to true
                highScoreAcheived = true;

                //WRITE newScore and newScoreName variables into Unity PlayerPrefs for the high score and high score name at this scoreIndex.
                PlayerPrefs.SetInt("highScore" + scoreIndex, highScore);
                PlayerPrefs.SetString("highScoreName" + scoreIndex, highScoreName);

                PlayerPrefs.SetInt("playerScore", newScore);
                PlayerPrefs.SetString("playerName", newName);

                //SET newScore equal to highScore
                newScore = highScore;

                //SET newName equal to highScoreName
                newName = highScoreName;

            }

        }
    }

    public void DisplayData()
    {
        //Declare Varibles
        int index;
        int score;
        string name;
        int highScore;
        string highScoreName;

        //IF highScoreAchieved is true
        if (highScoreAcheived)
        {

            //DISPLAY “Congratulations! You got a new high score!” to the messageDisplay text object.
            messageDisplay.text = "Congratulations!";
        }
        else
        {
            //DISPLAY “Better luck next time!” to the messageDisplay text object.
            messageDisplay.text = "Better luck next time!";
        }

        //FOR scoreIndex from 0 to 2
        for (int scoreIndex = 0; scoreIndex <= 2; scoreIndex++)
        {

            //READ highScore and highScoreName variables from Unity PlayerPrefs using the scoreIndex
            //CALL DisplayScore() with scoreIndex, highScore, and highScoreName
            highScore = PlayerPrefs.GetInt("highScore" + scoreIndex);
            highScoreName = PlayerPrefs.GetString("highScoreName" + scoreIndex);
            DisplayScore(scoreIndex, playerScore, playerName);
        }
        playerScore = PlayerPrefs.GetInt("playerScore");
        playerName = PlayerPrefs.GetString("playerName");
        //DISPLAY playerName and playerScore to the playerNameDisplay and playerScoreDisplay text objects
        playerNameDisplay.text = playerName;
        playerScoreDisplay.text = playerScore.ToString();

    }

    public void DisplayScore(int scoreIndex, int score, string playerName)
    {
        if (scoreIndex >= 0 && scoreIndex <= 2)
        {
            highScoreDisplays[scoreIndex].text = score.ToString();
        }
        else
        {
            highScoreDisplays[scoreIndex].text = null;
        }
        highScoreNameDisplays[scoreIndex].text = name;
    }
}
