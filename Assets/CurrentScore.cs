﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CurrentScore : MonoBehaviour
{
    public Text scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
