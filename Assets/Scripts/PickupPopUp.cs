using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PickupPopUp : MonoBehaviour
{
    private TextMeshPro text;
    private Color textColor;

    public float moveYSpeed = 30;
    public float disappearTimer = 0.5f;
    public float disappearSpeed = 6f;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        textColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(this)
        {
            transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

            disappearTimer -= Time.deltaTime;
            if (disappearTimer < 0)
            {
                textColor.a -= disappearSpeed * Time.deltaTime;
                text.color = textColor;
                if (textColor.a < 0)
                    Destroy(gameObject);
            }
        }
    }
}
