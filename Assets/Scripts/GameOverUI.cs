using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameOverUI : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject highScoreText;

    void Start()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("score").ToString();
        highScoreText.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        if(PlayerPrefs.GetInt("score",0) > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("score", 0));
        }
    }
}
