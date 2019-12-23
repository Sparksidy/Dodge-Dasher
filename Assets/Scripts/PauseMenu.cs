using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    bool pressed = false;
    private void Update()
    {

        #if UNITY_STANDALONE
             pressed = Input.GetKeyDown(KeyCode.Escape)
              if(pressed)
                {
                    if(isPaused)
                    {
                        Resume();
                    }
                    else
                    {
                        Pause();
                    }
                }
        #endif
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
