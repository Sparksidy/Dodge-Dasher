using UnityEngine;
using UnityEngine.UI;

public class DashBarUI : MonoBehaviour
{
    Image dashBar;
    public static float maxDashPoints = 50f;
    public static float dashPoints;
    void Start()
    {
        dashBar = GetComponent<Image>();
        dashPoints = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dashBar.fillAmount = dashPoints / maxDashPoints;
    }

}
