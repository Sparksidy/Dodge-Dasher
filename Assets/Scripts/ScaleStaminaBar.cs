using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleStaminaBar : MonoBehaviour
{
    private GameObject mainmana;
    private Vector3 currScale;
    private void OnEnable()
    {
        EventManager.scalemana += ScaleMana;
        mainmana = GameObject.Find("StaminaBar");
        currScale = mainmana.transform.localScale;
    }

    private void OnDisable()
    {
        UnscaleMana();
    }

    void ScaleMana()
    {
        mainmana.transform.localScale = currScale * 1.25f;
        EventManager.scalemana -= ScaleMana;
    }

    void UnscaleMana()
    {
        mainmana.transform.localScale = currScale;
    }
}
