﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour {
    void Awake()
    {
        Time.timeScale = 1.0f;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Play()
    {
        SceneManager.LoadScene("Peder");
    }
}
