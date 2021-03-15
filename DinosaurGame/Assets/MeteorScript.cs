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
       SK = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>();
       //SK.Score = ThisScore;
    }

    // Update is called once per frame
    void Update()
    {
        //SK.Score = ThisScore;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            
            Destroy(transform.gameObject);
            //ThisScore++;
            //SK.Score = ThisScore;
            //Add points
            //PlayerPrefs.SetInt("Score", SK.Score + 1);
            //print(PlayerPrefs.GetInt("Score"));
            //print(SK.Score);
            SK.Score++;
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            //Go to game-over screen
        }
    }
}
