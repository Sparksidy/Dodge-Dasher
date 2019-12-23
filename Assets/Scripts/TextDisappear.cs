using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisappear : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Color textColor;

    public float moveYSpeed = 2;
    public float disappearTimer = 0.5f;
    public float disappearSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        textColor = text.color;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            textColor.a -= disappearSpeed * Time.deltaTime;
            text.color = textColor;
            if (textColor.a < 0)
            {
                gameObject.SetActive(false);
               
            }
        }
    }

    private void OnDisable()
    {
        disappearTimer = 3.5f;
    }
}
