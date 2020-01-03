using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{

    private void Start()
    {
        if(AudioManager.AudioManager.m_instance)
        {
            AudioManager.AudioManager.m_instance.PlayMusic("BG_3");
        }
    }

    public void PlayGame()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Menu_UI");
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Menu_UI");
        Application.Quit();
    }

    public void PlayTutorial()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Menu_UI");
        
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayUISound()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Menu_UI");
    }

}
