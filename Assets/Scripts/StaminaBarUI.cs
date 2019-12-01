using UnityEngine;
using UnityEngine.UI;

public class StaminaBarUI : MonoBehaviour
{
    Image staminaBar;
    public  float maxStamina = 100f;
    public  float staminaDashLoss = 30;
    public  float staminaMovementGain = 3;
    public  float staminaGainDashPoints = 15;
    public  float staticStaminaLoss = 20;

    public static float stamina;

    CharacterController player;

    void Start()
    {
        staminaBar = GetComponent<Image>();
        stamina = 100;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if(player.IsPlayerDashing())
        {
            stamina = Mathf.Clamp(stamina - (staminaDashLoss * Time.deltaTime), 0.0f, maxStamina);
        }
        if (player.IsPlayerMoving())
        {
            stamina = Mathf.Clamp(stamina + (staminaMovementGain * Time.deltaTime), 0.0f, maxStamina);
        }
        if(player.IncreaseStamina())
        {
            stamina = Mathf.Clamp(stamina + staminaGainDashPoints, 0.0f, maxStamina);

            player.increaseStamina = false;
        }
        else if(!player.IsPlayerMoving())
        {
            stamina = Mathf.Clamp(stamina - (staticStaminaLoss * Time.deltaTime), 0.0f, maxStamina);
        }

        staminaBar.fillAmount = stamina / maxStamina;
    }

}
