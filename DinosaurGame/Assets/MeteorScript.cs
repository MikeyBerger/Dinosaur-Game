using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    private ScoreKeeper SK;
    public int ThisScore;

    // Start is called before the first frame update
    void Start()
    {
       SK.Score = ThisScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(transform.gameObject);
            ThisScore++;
            //Add points
            SK.Score = PlayerPrefs.GetInt("Score", SK.Score + 1);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            //Go to game-over screen
        }
    }
}
