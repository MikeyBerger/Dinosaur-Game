using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem
{
    public int Score; //Current score
    public int HiScore; //High score
    private ScoreKeeper SK; //ScoreKeeper Class

    // Start is called before the first frame update
    void Start()
    {
        SK = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>(); //Assigns a value to SK
        Score = 0; //Score equals 0
        HiScore = PlayerPrefs.GetInt("HiScore"); //Calls the saved high score
    }

    // Update is called once per frame
    void Update()
    {
        SK.Update(); //Calls the "Update" function from the "ScoreKeeper" Script
    }
}
