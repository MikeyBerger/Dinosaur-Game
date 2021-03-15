using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float Timer; //A timer
    public float Limit; //When an object should be spawned
    private int RandTarget; //Not in use
    public Transform []Targets; //The object to be spawned
    public Vector3 Center; //Where to draw the spawn area
    public Vector3 Size; //Size of the spawn area

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RandTarget = Random.Range(0, 0);
        Vector3 Pos = Center + new Vector3(Random.Range(-Size.x, Size.x), Random.Range(-Size.y, Size.y), 0); //Allows for random position spawning
        

        if (Timer >= Limit) //If the timer reaches the limit
        {
            Instantiate(Targets[0], Pos, transform.rotation); //Spawn an object
            Timer = 0; //Reset the timer
        }

        Timer += Time.deltaTime; //Time is equal to real-time
    }

    private void OnDrawGizmosSelected() //Draw a gizmo(something that helps aid in the game-making process)
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f); //The color of this gizmo is red
        Gizmos.DrawCube(Center, Size); //The center and size of the gizmo
    }
}
