using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    private GameObject[] playerArr = new GameObject[4];
    private int numberOfDeadPlayers = 0;
    private bool deadRegistered1 = false;
    private bool deadRegistered2 = false;
    private bool deadRegistered3 = false;
    private bool deadRegistered4 = false;

    public GameObject endGameObject;

    // Use this for initialization
    void Start ()
    {
        playerArr = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playerArr[0].GetComponent<Movement2>().dead && !deadRegistered1)
        {
            numberOfDeadPlayers += 1;
            deadRegistered1 = true;
        }
        if (playerArr[1].GetComponent<Movement2>().dead && !deadRegistered2)
        {
            numberOfDeadPlayers += 1;
            deadRegistered2 = true;
        }
        if (playerArr[2].GetComponent<Movement2>().dead && !deadRegistered3)
        {
            numberOfDeadPlayers += 1;
            deadRegistered3 = true;
        }
        if (playerArr[3].GetComponent<Movement2>().dead && !deadRegistered4)
        {
            numberOfDeadPlayers += 1;
            deadRegistered4 = true;
        }


        if(numberOfDeadPlayers >= 3)
        {
            Time.timeScale = 0.0f;
            endGameObject.SetActive(true);
        }


    }
    public void Replay()
    {
        SceneManager.LoadScene("Peder");
    }
}
