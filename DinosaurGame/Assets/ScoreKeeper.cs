using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    public int Score; //Sets the score for the game
    public int HiScore;

    // Start is called before the first frame update
    void Start()
    {
        Score = Score = PlayerPrefs.GetInt("Score", 0);
        HiScore = PlayerPrefs.GetInt("HiScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
