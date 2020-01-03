using UnityEngine;
using UnityEngine.UI;

public class StaminaBarUI : MonoBehaviour
{
    Image staminaBar;
    public  float maxStamina = 100f;
    public  float staminaDashLoss = 20;
    public  float staminaMovementGain = 5;
    public  float staminaGainDashPoints = 25;
    public  float staticStaminaLoss = 20;

    public static float stamina;
    public static bool startDraining = false;

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
        if(startDraining)
        {
            if (player.IsPlayerDashing())
            {
                stamina = Mathf.Clamp(stamina - (staminaDashLoss * Time.deltaTime), 0.0f, maxStamina);
            }
            if (player.IsPlayerMoving())
            {
                stamina = Mathf.Clamp(stamina + (staminaMovementGain * Time.deltaTime), 0.0f, maxStamina);
            }
            if (player.IncreaseStamina())
            {
                stamina = Mathf.Clamp(stamina + staminaGainDashPoints, 0.0f, maxStamina);

                player.increaseStamina = false;
            }
            else if (!player.IsPlayerMoving())
            {
                stamina = Mathf.Clamp(stamina - (staticStaminaLoss * Time.deltaTime), 0.0f, maxStamina);
            }

            staminaBar.fillAmount = stamina / maxStamina;
        }
        
    }

}
