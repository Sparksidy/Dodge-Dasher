using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDashArea : MonoBehaviour
{
    public GameObject dashButton;
    private void OnEnable()
    {
        EventManager.showDashArea += ShowDashIcon;
    }
    
    private void OnDisable()
    {
        EventManager.showDashArea -= ShowDashIcon;
    }

    void ShowDashIcon()
    {
        dashButton.gameObject.SetActive(true);
    }
}
