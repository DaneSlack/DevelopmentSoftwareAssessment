using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    //Declare Varibles
    [SerializeField]
    public TMP_Text messageDisplay;
    [SerializeField]
    public TMP_Text playerNameDisplay;
    [SerializeField]
    public TMP_Text playerScoreDisplay;
    [SerializeField]
    public TMP_Text[] highScoreDisplays;
    [SerializeField]
    public TMP_Text[] highScoreNameDisplays;
    [SerializeField]
    public bool highScoreAchieved = false;
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
        int highScore;
        string highScoreName;

        //READ playerScore and playerName variables from Unity PlayerPrefs
        int playerScore = PlayerPrefs.GetInt("playerScore");
        string playerName = PlayerPrefs.GetString("playerName");

        //INITIALISE newScore and newName variables to be equal to playerScore and playerName
        newScore = playerScore;
        newName = playerName;

        //FOR scoreIndex from 0 to 2
        for (int scoreIndex = 0; scoreIndex < 2; scoreIndex++)
        {

            //READ highScore and highScoreName variables from Unity PlayerPrefs using the scoreIndex
            highScore = PlayerPrefs.GetInt("highScore" + scoreIndex);
            highScoreName = PlayerPrefs.GetString("highScoreName" + scoreIndex);

            //IF newScore is greater than highScore THEN
            if (newScore > highScore)
            {
                //SET highScoreAchieved to true
                highScoreAchieved = true;

                //WRITE newScore and newScoreName variables into Unity PlayerPrefs for the high score and high score name at this scoreIndex.
                PlayerPrefs.SetInt("highScore" + scoreIndex, newScore);
                PlayerPrefs.SetString("highScoreName" + scoreIndex, newName);

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
        int highScore;
        string highScoreName;
        string playerName = PlayerPrefs.GetString("playerName");
        int playerScore = PlayerPrefs.GetInt("playerScore");

        //IF highScoreAchieved is true
        if (highScoreAchieved == true)
        {

            //DISPLAY “Congratulations! You got a new high score!” to the messageDisplay text object.
            messageDisplay.text = "Congratulations!";
        }
        else
        {
            //DISPLAY “Better luck next time!” to the messageDisplay text object.
            messageDisplay.text = "Better luck next time!";
        }

        
        //DISPLAY playerName and playerScore to the playerNameDisplay and playerScoreDisplay text objects
        playerNameDisplay.text = playerName;
        playerScoreDisplay.text = playerScore.ToString();

        //FOR scoreIndex from 0 to 2
        for (int scoreIndex = 0; scoreIndex <= 2; scoreIndex++)
        {
            //READ highScore and highScoreName variables from Unity PlayerPrefs using the scoreIndex
            highScore = PlayerPrefs.GetInt("highScore" + scoreIndex);
            highScoreName = PlayerPrefs.GetString("highScoreName" + scoreIndex);
            //CALL DisplayScore() with scoreIndex, highScore, and highScoreName
            DisplayScore(scoreIndex, highScore, highScoreName);
        }
    }

    public void DisplayScore(int scoreIndex, int highScore, string highScoreName)
    {
        //IF score is greater than 0
        if (scoreIndex > 0)
        {
            //DISPLAY score to the highScoreDisplays at index
            highScoreDisplays[scoreIndex].text = highScore.ToString();
        }
        else
        {
            //DISPLAY the empty string to the highScoreDisplays at index.
            highScoreDisplays[scoreIndex].text = null;
        }
        //DISPLAY name to the highScoreNameDisplays at index
        highScoreNameDisplays[scoreIndex].text = highScoreName;
    }
}
