using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour {

    // rigidbody = coin coin now effect the rigidbody

    
    public Rigidbody Coin;
    public bool inWindArea = false;
    public GameObject windZone;
    public float maxYVel = 100;
    public float yvel = 2;
    public float direction = 0;
    public static Vector3 negativeInfinitely;
    public Image[] Lives;
    private int hits = 1;
    public GameManager gameManager;
    public float speed = 1;

    
    

    void Start () {
        Coin.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //controls
        //increase vel
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Coin.AddForce(0, yvel, 0 * Time.deltaTime);
            direction = -1;
        }
        //movement to the left
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Coin.AddForce(Vector3.left * 250);
        }
        //movement to the right
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Coin.AddForce(Vector3.right * 250);
        }

        
	}

    private void FixedUpdate()
    {
        if (inWindArea)
        {
            //this adds  the force to the coin if its in the wind area. its will get both the direction and the power
            Coin.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().power);
        }
        Debug.Log(inWindArea);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "windArea")
        {
            //this is pretty much turning on the wind area if a game object enter this gameobject tag windArea
            windZone = other.gameObject;
            inWindArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "windArea")
        {
            //this turns the gameobject taged windArea off if the object exits
            inWindArea = false;
        }
    }
    /*private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Wall")
        {
            Damage();
        }
    }*/
    /*private void Damage()
    {
        Lives[hits].enabled = false;
        hits--;
        if(hits < 0)
        {
            GameOver();
        }
    }*/

    /*private void GameOver()
    {
        gameManager.GameOver();
        this.gameObject.SetActive(false);
    }*/


}
