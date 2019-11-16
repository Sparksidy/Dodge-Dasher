using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public Sprite[] sprites;

    public Image HeartUI;

    private CharacterController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        HeartUI.sprite = sprites[5];
    }

    private void Update()
    {
        int number = 100 / sprites.Length;
        int index = ((int)player.GetHealth() / number);
      
        HeartUI.sprite = sprites[index - 1];
    }

}
