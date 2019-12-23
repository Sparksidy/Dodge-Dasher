using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Image health;
    public GameObject Player;
    public float maxHealthAmount = 100.0f;
    CharacterController player;

    void Start()
    {
        health = GetComponent<Image>();
        player = Player.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (player)
        {
            health.fillAmount = player.GetHealth() / maxHealthAmount;
        }
    }
    
}
