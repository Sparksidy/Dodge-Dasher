using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DashPoint : MonoBehaviour
{
    public GameObject DashpointPickupEffect;
    public GameObject PickupRewards;

    private AudioManager.AudioManager audioManager;
    private TextMeshPro text;

    private void Start()
    {
        audioManager = AudioManager.AudioManager.m_instance;
        text = PickupRewards.GetComponent<TextMeshPro>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (audioManager)
                audioManager.PlaySFX("TreasureSpawn");


            CharacterController player = other.GetComponent<CharacterController>();
            int score = player.GetPerDashPointValue();
            text.SetText("+" + score.ToString());
            Instantiate(PickupRewards, transform.position, transform.rotation);

            Instantiate(DashpointPickupEffect, transform.position, transform.rotation);

            player.Score();
            player.EnableFuelStamina();
            player.GenerateNewDashPoint();
            Destroy(gameObject);
        }
    }
}
