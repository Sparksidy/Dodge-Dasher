using UnityEngine;
using UnityEngine.UI;
public class OrbPickup : MonoBehaviour
{
    private Text orbs;
    public GameObject Player;

    void Start()
    {
        orbs = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
        {
            CharacterController player = Player.GetComponent<CharacterController>();
            if (player)
            {
                orbs.text = player.GetScore().ToString();
            }
        }
    }
}
