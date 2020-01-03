using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverUI : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject highScoreText;

    void Start()
    {
        AudioManager.AudioManager.m_instance.PlayMusic("Game_Over");
        scoreText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("score").ToString();
        highScoreText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        if(PlayerPrefs.GetInt("score",0) > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("score", 0));
        }
    }

    public void RestartGame()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Menu_UI");
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        AudioManager.AudioManager.m_instance.PlaySFX("Menu_UI");
        Application.Quit();
    }

}
