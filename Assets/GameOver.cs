using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text gameOver;
    private void Start()
    {
        gameOver.enabled = false;
    }
    public void Show()
    {
        gameOver.enabled = true;
    }
}
