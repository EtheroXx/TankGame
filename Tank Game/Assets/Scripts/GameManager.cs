using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isPaused;
    public MenuUI menu;
    public Text tanksDestroyedTxt;
    public float GameTimer;
    public Text timeTxt;
    private int enemyTanksDestroyed = 0;
    public Text gameOverTxt;

    public enum GameState
    {
        Playing,
        GameOver
    };
    private GameState gameState;

    void Awake()
    {
        isPaused = false;
        gameState = GameState.Playing;
        tanksDestroyedTxt.text = enemyTanksDestroyed.ToString();
        gameOverTxt.text = "";
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.Playing:
                GSPlaying();
                break;
            case GameState.GameOver:
                GSGameOver();
                break;
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            //Application.Quit();
            TogglePause();
        }
    }

    public void Destroyed(bool isPlayer)
    {
        bool gameOver = false;
        string message = "";
        if (isPlayer)
        {
            message = "Game Over, You Destroyed " + enemyTanksDestroyed + " Enemy Tanks";
            gameOver = true;
        }

        else
        {
            enemyTanksDestroyed ++;
            tanksDestroyedTxt.text = enemyTanksDestroyed.ToString();
            Debug.Log("Tanks Destroyed: " + enemyTanksDestroyed);
        }

        if (gameOver)
        {
            gameState = GameState.GameOver;
            gameOverTxt.text = message;
        }

    }

    void GSPlaying()
    {
        Debug.Log("Playing State");
        GameTimer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(GameTimer / 60);
        int seconds = Mathf.FloorToInt(GameTimer % 60);
        timeTxt.text = string.Format("{0:0} : {1:00}", minutes, seconds);
    }

    void GSGameOver()
    {
        Debug.Log("Game Over State");
        if (Input.GetKeyUp(KeyCode.Return) == true)
        {
            Debug.Log("Restarting");
            SceneManager.LoadScene("Game");
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        menu.PauseGame(isPaused);
    }
}
