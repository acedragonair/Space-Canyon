using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject menu;
    public GameObject gameOver;
    public GameObject game;
    private bool isGameover = false;


	// Use this for initialization
	void Start () {
        game.SetActive(false);
        gameOver.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void GameOver()
    {
        game.SetActive(false);
        gameOver.SetActive(true);
        isGameover = true;
    }
    
    public void StartGame()
    {
        menu.SetActive(true);
        game.SetActive(true);
    }

}
