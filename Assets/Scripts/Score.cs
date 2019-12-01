using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    private TextMeshProUGUI score;
    public GameObject Player;

    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
        {
            CharacterController player = Player.GetComponent<CharacterController>();
            if (player)
            {
                score.SetText(player.GetScore().ToString());
            }
        }
    }
}
