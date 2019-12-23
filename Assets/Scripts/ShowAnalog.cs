using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAnalog : MonoBehaviour
{
    private GameObject joystick;
    private GameObject background;
    private void OnEnable()
    {
        joystick = GameObject.Find("Dynamic Joystick");
        background = joystick.GetComponent<DynamicJoystick>().GetBackgroundJoystickObject();
        EventManager.showJoystick += ScaleJoystick;
    }

    private void OnDisable()
    {
        EventManager.showJoystick -= ScaleJoystick;
        background.SetActive(false);
    }


    public void ScaleJoystick()
    {
        if (!background.gameObject.activeSelf)
        {
            background.gameObject.SetActive(true);
        }
    }
}
