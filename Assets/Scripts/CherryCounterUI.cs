using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class CherryCounterUI : MonoBehaviour
{
    Text counter;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        counter = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player)
        {
            int count = player.GetComponent<CharacterController>().GetCherryPickups();

            counter.text = count.ToString();
        }
       
    }
}
