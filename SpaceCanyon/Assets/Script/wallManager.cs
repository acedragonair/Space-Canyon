using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wallManager : MonoBehaviour {

    //this is an array to store the different prefabs
    public GameObject[] walltiles;

    //this hold the transform value of the player
    private Transform playerWallPos;

    //this will hold the the value affecting the spawning location in this y axis
    private float spawnY = -10.0f;

    //create a float for the lenght of the prefabs
    private float L_wall = 20.0f;

    //create how many of the objects you want to spawn
    private int wallAmount = 3;

    //tells which prefabs are being spawned
    private List<GameObject> animatedPrefabs;

    //this holds the value of the last prefad in the list
    private int prefabIndex = 0;

    //this holds the value of the amount will halt delete
    private float leeway = 20.0f;//(this is 2prefab)


    //__________________________________________________________________________
    private int score = -3;

    public Text scoreText;
    //_______________________________________________________

    // Use this for initialization
    void Start () {
        //this creates the list at start of the game
        animatedPrefabs = new List<GameObject>();

        //this will give the variable the player's postiion.
        //playerWallPos = GameObject.Find("coin").GetComponent<Transform>(); atempt

        playerWallPos = GameObject.FindGameObjectWithTag("Player").transform;
        
        //this will loop the prefabs beign spawned
        for (int i = 0; i < wallAmount; i++ )
        {

            if (i < 2)
            {
                //omg dude call the spawn funtion aaaaaaaaaaaaaaaaaarrrrrrrrrrrrrrgggggggg ****remember to call funtion******
                wallSpawn(0);
            }
            else
            {
                //omg dude call the spawn funtion aaaaaaaaaaaaaaaaaarrrrrrrrrrrrrrgggggggg ****remember to call funtion******
                wallSpawn();
            }
            
        }
	}
	
	// Update is called once per frame
	void Update () {
        // make sure you say its less than because it is going down making it negative
        if (-playerWallPos.position.y - leeway > (spawnY - wallAmount * L_wall))
        {
            wallSpawn();


            DeleteWall();
            
        }

    }

    //create a function to spawn the prefabs
    private void wallSpawn(int prefabWallIndex = -1)
    {
        GameObject Wall;
       if (prefabWallIndex == -1)
       {
            //this will instantiate walls inside the array
            Wall = Instantiate(walltiles[randomPI()]) as GameObject;
       }
        else
        {
            Wall = Instantiate(walltiles[prefabWallIndex]) as GameObject;
            
        } 

        //this will make sure that the prfab becomes a child of the Prefabwallmanager (holds the script) when instantiate.
        Wall.transform.SetParent(transform);

        //this tells the firction of where i want it to spawn
        Wall.transform.position = Vector3.down * spawnY;

        //this holds the location(transformation) value of the Gameobject as it increments
        spawnY += L_wall;

        //this adds GO "Wall to the list
        animatedPrefabs.Add(Wall);

        
            
          Playerscore();

    }

    //this function will randomize the prefab being spawned
    private int randomPI()
    {
        if (walltiles.Length <= 1)
        {
            return 0;
        }

        int randomIndex = prefabIndex;
        while(randomIndex == prefabIndex)
        {
            randomIndex = Random.Range(0, walltiles.Length);
           //this will randomize inside the idex the range between the 0 and max
        }
        prefabIndex = randomIndex;
        return randomIndex;
    }

    //this function will destroy the GO prefab being created in the list as the game progress
    private void DeleteWall()
    {
        //the destroy funtion is a unity function that destroys whats in the perimiter
        Destroy(animatedPrefabs[0]);
        //the RemoveAt removes the GO at the spesific number (this narrows the deletion)
        animatedPrefabs.RemoveAt(0);
    }

   /*private void Playerscore()
    {
        score += Time.deltaTime;
        //turns the score into strings
        scoreText.text = ((int)score).ToString();
    }*/

    private void Playerscore()
    {
         score++;
         scoreText.text = score.ToString();
    }
}
