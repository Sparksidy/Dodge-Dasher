using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Text health;
    public GameObject Player;

    void Start()
    {
        health = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player)
        {
            CharacterController player = Player.GetComponent<CharacterController>();
            if (player)
            {
                health.text = "Health:  " + player.GetHealth();
            }
        }
       
    }
}
