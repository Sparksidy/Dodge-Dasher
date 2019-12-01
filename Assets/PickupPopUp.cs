using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PickupPopUp : MonoBehaviour
{
    private float disappearTimer;
    private TextMeshPro text;
    private Color textColor;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        textColor = text.color;
        disappearTimer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float moveYSpeed = 3f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            float disappearSpeed = 6f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            text.color = textColor;
            if (textColor.a < 0)
                Destroy(gameObject);
        }
    }
}
