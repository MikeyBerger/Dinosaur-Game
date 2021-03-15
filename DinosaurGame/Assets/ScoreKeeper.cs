using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    public int Score; //Sets the score for the game
    public int HiScore; //Variable for the high score
    public Text ScoreText; //Text display for the score
    public Text HiScoreText; //Text display for the high score

    // Start is called before the first frame update
    void Start()
    {
        Score = 0; //Score equals 0 at the start of the game
        HiScore = PlayerPrefs.GetInt("HiScore"); //Saves the high score
    }

    // Update is called once per frame
    public void Update()
    {
        //If the current score is greater than the high score
        if (Score > HiScore)
        {
            HiScore = Score; //The new high score is the current score
            PlayerPrefs.SetInt("HiScore", HiScore); //Save the new high score
        }

        ScoreText.text = ("Score: " + Score.ToString()); //Display the current score
        HiScoreText.text = ("High Score: " + HiScore.ToString()); //Display the high score
    }
}
