using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int enemyTanksDestroyed = 0;

    public enum GameState
    {
        Playing,
        GameOver
    };
    private GameState gameState;

    void Awake()
    {
        gameState = GameState.Playing;
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
            Application.Quit();
        }
    }

    public void Destroyed(bool isPlayer)
    {
        bool gameOver = false;
        if (isPlayer)
        {
            Debug.Log("Game Over, You Destroyed " + enemyTanksDestroyed + " Enemy Tanks");
            gameOver = true;
        }

        else
        {
            enemyTanksDestroyed ++;
            Debug.Log("Tanks Destroyed: " + enemyTanksDestroyed);
        }

        if (gameOver)
        {
            gameState = GameState.GameOver;
        }

    }

    void GSPlaying()
    {
        Debug.Log("Playing State");
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
}
