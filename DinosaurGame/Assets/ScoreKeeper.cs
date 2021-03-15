using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    public int Score; //Sets the score for the game
    public int HiScore;
    public Text ScoreText;
    public Text HiScoreText;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        HiScore = PlayerPrefs.GetInt("HiScore");
    }

    // Update is called once per frame
    public void Update()
    {
        if (Score > HiScore)
        {
            HiScore = Score;
            PlayerPrefs.SetInt("HiScore", HiScore);
        }

        ScoreText.text = Score.ToString();
        HiScoreText.text = HiScore.ToString();
    }
}
