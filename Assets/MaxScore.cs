using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MaxScore : MonoBehaviour
{
    public Text scoreText;
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.maxScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.maxScore.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            //SceneManager.LoadScene(0);
        }
    }
}
