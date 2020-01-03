using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public int countdownTime;
    private TextMeshProUGUI text;
    GameObject spawners;

    private void Start()
    {
        AudioManager.AudioManager.m_instance.PlayMusic("BG_1");
        text = GetComponent<TextMeshProUGUI>();
        spawners = GameObject.Find("Spawners");
        StaminaBarUI.startDraining = false;
        spawners.SetActive(false);
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while(countdownTime > 0)
        {
            text.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        text.text = "GO!";

        yield return new WaitForSeconds(1f);



        StaminaBarUI.startDraining = true;
        spawners.SetActive(true);

        text.gameObject.SetActive(false);
    }

}
