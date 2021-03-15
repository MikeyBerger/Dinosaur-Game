using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeteorScript : MonoBehaviour
{
    private ScoreKeeper SK; //The "ScoreKeeper" Class
    public int ThisScore; //An integer for keeping score

    // Start is called before the first frame update
    void Start()
    {
       SK = GameObject.FindGameObjectWithTag("ScoreKeeper").GetComponent<ScoreKeeper>(); //Assigns a value to SK
       //SK.Score = ThisScore;
    }

    // Update is called once per frame
    void Update()
    {
        //SK.Score = ThisScore;
    }

    private void OnCollisionEnter2D(Collision2D collision) //If the meteor collides with something
    {

        if (collision.gameObject.tag == "Ground") //If the collider is tagged "Ground"
        {
            
            Destroy(transform.gameObject); //Destroy this object
            SK.Score++; //Increase the score
        }

        if (collision.gameObject.tag == "Player") //If the collider is tagged "Player"
        {
            Destroy(collision.gameObject); //Destroy the player
            SceneManager.LoadScene(1); //Go to the game over scene
        }
    }
}
