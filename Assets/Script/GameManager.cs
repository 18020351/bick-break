using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public int level = 1;
    public Ball ball;
    public Paddle paddle;
    public Brick[] bricks;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void Start()
    {
        // NewGame();
    }
    public void NewGame()
    {
        score = 0;
        lives = 3;
        LoadLevel(1);
    }
    private void LoadLevel(int level)
    {
        this.level = level;
        SceneManager.LoadScene(level);
    }
    public void Score(Brick brick)
    {
        score += brick.points;
        if (Cleared())
        {
            LoadLevel(level + 1);
        }
    }
    private void ResetLevel()
    {
        ball.ResetBall();
        paddle.ResetPaddle();
    }
    public void GameOver()
    {
        NewGame();
    }
    public void Miss()
    {
        lives--;
        if (lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        bricks = FindObjectsOfType<Brick>();
    }
    private bool Cleared()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].unBreakAble)
            {
                return false;
            }
        }
        return true;
    }
}
