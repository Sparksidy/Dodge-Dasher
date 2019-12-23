using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleHealthBar : MonoBehaviour
{
    private GameObject health;
    private Vector3 currScale;
    private void OnEnable()
    {
        EventManager.scalemana += ScaleHealth;
        health = GameObject.Find("HealthBar");
        currScale = health.transform.localScale;
    }

    private void OnDisable()
    {
        UnscaleHealth();
    }

    void ScaleHealth()
    {
        health.transform.localScale = currScale * 1.25f;
        EventManager.scalemana -= ScaleHealth;
    }

    void UnscaleHealth()
    {
        if(health)
            health.transform.localScale = currScale;
    }
}
