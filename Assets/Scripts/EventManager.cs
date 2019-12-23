using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void TutorialAction();
    public static event TutorialAction showJoystick;
    public static event TutorialAction showDashArea;
    public static event TutorialAction scalemana;
    public static event TutorialAction scalehealthbar;
    public static event TutorialAction activateEnemy;

    private void Update()
    {
        if (showJoystick != null)
        {
            showJoystick();
        }
        else if(showDashArea != null)
        {
            showDashArea();
        }
        else if(scalemana != null)
        {
            scalemana();
        }
        else if(scalehealthbar != null)
        {
            scalehealthbar();
        }
        else if(activateEnemy != null)
        {
            activateEnemy();
        }
    }

}
