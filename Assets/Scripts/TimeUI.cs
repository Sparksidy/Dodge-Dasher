using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeUI : MonoBehaviour
{
    Text time;

    private float currTime;

    void Start()
    {
        time = GetComponent<Text>();
        currTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;

        TimeSpan timer = TimeSpan.FromSeconds(currTime);

        time.text = "Time:  " + timer.ToString(@"mm\:ss\:f");
    }
}