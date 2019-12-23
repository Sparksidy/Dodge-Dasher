using UnityEngine;

public class ResizeCamera : MonoBehaviour
{
    private void Start()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = 24.0f * (1.0f / currentAspect) * 0.5f;
    }
}
