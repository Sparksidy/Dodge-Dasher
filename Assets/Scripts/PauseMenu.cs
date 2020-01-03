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
        AudioManager.AudioManager.m_instance.PlaySFX("Menu_UI");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void PlayUISound()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Menu_UI");
    }

    public void Pause()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Menu_UI");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void LoadMenu()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Menu_UI");
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Menu_UI");
        Application.Quit();
    }
}
