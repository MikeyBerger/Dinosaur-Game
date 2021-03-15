using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSystem
{
    public int Score;
    public int HiScore;
    private ScoreKeeper SK;

    // Start is called before the first frame update
    void Start()
    {
        SK = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
        Score = 0;
        HiScore = PlayerPrefs.GetInt("HiScore");
    }

    // Update is called once per frame
    void Update()
    {
        SK.Update();
    }
}
