using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public float Speed; //The speed at which the ground will move
    public Transform SpawnPoint; //The point at which a new piece of ground will spawn
    public Transform[] GroundPrefabs; //Different pieces of ground that can spawn
    private int RandPrefab; //The number of pieces of ground
    public int Min; //First object in the list above
    public int Max; //Last object in the list above

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed, 0, 0); //Tells the ground to move
        RandPrefab = Random.Range(Min, Max); //Sets "RandPrefab" to a random number (which will be declared in the Unity Inspector
    }

    private void OnTriggerEnter2D(Collider2D collision) //Upon touching a 2Dtrigger
    {
        if (collision.gameObject.tag == "Spawner") //If it's tagged "Spawner"
        {
            Instantiate(GroundPrefabs[RandPrefab], SpawnPoint.position, SpawnPoint.rotation); //Spawn a piece of ground
        }

        if (collision.gameObject.tag == "Destroyer") //If it's tagged "Destroyer"
        {
            Destroy(gameObject); //Destroy this piece of ground
        }
    }
}
