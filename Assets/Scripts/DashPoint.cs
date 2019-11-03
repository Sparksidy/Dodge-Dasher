using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashPoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            CharacterController player = other.GetComponent<CharacterController>();
            player.Score();
            player.EnableFuelStamina();
            player.GenerateNewDashPoint();
            Destroy(gameObject);
        }
    }
}
