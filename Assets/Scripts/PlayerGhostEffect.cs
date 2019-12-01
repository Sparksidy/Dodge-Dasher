using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostEffect : MonoBehaviour
{

    SpriteRenderer sprite;
    public float timer = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        transform.position =  GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.localScale = GameObject.FindGameObjectWithTag("Player").transform.localScale;

        sprite.sprite = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().sprite;
        sprite.color = new Vector4(50, 50, 50, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
