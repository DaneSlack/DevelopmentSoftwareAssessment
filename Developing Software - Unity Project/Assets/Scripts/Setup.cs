using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Setup : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField playerScore;
    [SerializeField]
    private TMP_InputField playerName;
    [SerializeField]
    private TMP_InputField highScore0;
    [SerializeField]
    private TMP_InputField highScoreName0;
    [SerializeField]
    private TMP_InputField highScore1;
    [SerializeField]
    private TMP_InputField highScoreName1;
    [SerializeField]
    private TMP_InputField highScore2;
    [SerializeField]
    private TMP_InputField highScoreName2;


    public void Save()
    {
        // Set all player prefs
        PlayerPrefs.SetInt("playerScore", Int32.Parse(playerScore.text));
        PlayerPrefs.SetString("playerName", playerName.text);
        PlayerPrefs.SetInt("highScore0", Int32.Parse(highScore0.text));
        PlayerPrefs.SetString("highScoreName0", highScoreName0.text);
        PlayerPrefs.SetInt("highScore1", Int32.Parse(highScore1.text));
        PlayerPrefs.SetString("highScoreName1", highScoreName1.text);
        PlayerPrefs.SetInt("highScore2", Int32.Parse(highScore2.text));
        PlayerPrefs.SetString("highScoreName2", highScoreName2.text);

        // Save
        PlayerPrefs.Save();

        // Change scenes
        SceneManager.LoadScene("Highscore");
    }



}
