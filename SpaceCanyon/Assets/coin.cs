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
    private int hits = 3;
    public GameManager gameManager;

    public Vector3 cam;//store the location of the camera xyz
    

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
            Coin.AddForce(-1, 0, 0 * Time.deltaTime);
            direction = -1;
        }
        //movement to the right
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Coin.AddForce(1, 0, 0 * Time.deltaTime);
            direction = 1;
        }
	}

    private void FixedUpdate()
    {
        if (inWindArea)
        {
            Coin.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().power);
        }
        Debug.Log(inWindArea);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "windArea")
        {
            windZone = other.gameObject;
            inWindArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "windArea")
        {
            inWindArea = false;
        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "Wall")
        {
            Damage();
        }
    }
    private void Damage()
    {
        Lives[hits].enabled = false;
        hits--;
        if(hits < 0)
        {
            gameOver();
        }
    }
    private void gameOver()
    {
        gameManager.GameOver();
        this.gameObject.SetActive(false);
    }
}
