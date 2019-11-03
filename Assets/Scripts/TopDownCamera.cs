using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform m_Target;
    public float smoothSpeed;
    public Vector3 offset;
    private void FixedUpdate()
    {
        if(m_Target)
        {
            Vector3 desiredPosition = m_Target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }


}
