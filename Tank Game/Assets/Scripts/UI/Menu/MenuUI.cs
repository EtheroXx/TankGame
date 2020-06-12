using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public GameObject exitMenu;

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ExitMenu(bool exiting)
    {
        exitMenu.SetActive(exiting);
    }

    public void PauseGame(bool pausing)
    {
        GameManager.isPaused = pausing;
        if (pausing == true)
        {
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1f;
        }
        ExitMenu(pausing);
    }
}
