using UnityEngine;
using UnityEngine.UI;

public class HealthCounterUI : MonoBehaviour
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
        if (player)
        {
            float count = player.GetComponent<CharacterController>().GetHealth();
            counter.text = count.ToString();
        }

    }
}