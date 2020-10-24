using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(FlappyAnim))]
public class FlappyControl : MonoBehaviour
{

    FlappyAnim flappyAnim;
    Rigidbody2D body;
    CurrentScore currentScore;
    public float jumpForce;
    public float rotationSpeed;
    public PipeSpawner pipeSpawner;
    public Score score;
    GameOver showGameOver;

    enum GameStatus
    {
        menu,
        game,
        gameOver
    }
    GameStatus status = GameStatus.menu;
    public float floor;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        flappyAnim = GetComponent<FlappyAnim>();
        currentScore = GetComponent<CurrentScore>();
        showGameOver = GetComponent<GameOver>();
    }
    
    void Update()
    {
        switch (status)
        {
            case GameStatus.menu:
                UpdateMenu();
                break;
            case GameStatus.game:
                UpdateGame();
                break;
            case GameStatus.gameOver:
                UpdateGameOver();
                break;
            default:
                break;
        }
        flappyAnim.UpdateYVelocity(body.velocity.y);
    }

    void UpdateGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            body.velocity = Vector2.up * jumpForce;
            flappyAnim.Jump();
        }
        if(body.position.y < floor)
        {
            GameOver();
        }
        score.maxScore++;
        currentScore.UpdateScore();
    }
    void UpdateMenu()
    {
        if (Input.GetMouseButtonDown(0))
        {
            body.velocity = Vector2.up * jumpForce;
            flappyAnim.Jump();
            status = GameStatus.game;
        }
        if (body.position.y < 0)
        {
            body.velocity = Vector2.up * jumpForce;
            flappyAnim.Jump();
        }
    }
    void UpdateGameOver()
    {
        body.transform.eulerAngles = new Vector3(0, 0, body.transform.eulerAngles.z + 360f * rotationSpeed * Time.deltaTime);
        //Implement a scoreboard scene

        showGameOver.Show();
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver();
    }
    void GameOver()
    {
        if(status == GameStatus.gameOver)
        {
            return;
        }
        body.velocity = Vector2.up * jumpForce;
        pipeSpawner.Stop();
        status = GameStatus.gameOver;
    }
}