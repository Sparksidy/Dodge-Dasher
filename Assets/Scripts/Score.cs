using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    Text score;
    public GameObject Player;

    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player)
        {
            CharacterController player = Player.GetComponent<CharacterController>();
            if (player)
            {
                score.text = "Score:  " + player.GetScore();
            }
        }
    }
}
