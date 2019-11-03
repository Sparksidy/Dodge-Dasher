using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;

    private Transform target;
    public float followDuration = 5f;
    public float breakDuration = 2f;
    public int damage;

    private float breakTimer;
    private float waitTimer;

    private bool startFollow;

    public GameObject bloodEffect;
    private GameObject player;

    public int health = 50;

    public enum EnemyType
    {
        EASY = 0,
        MEDIUM,
        HARD,
        TOTAL
    }
    public EnemyType enemytype;

    void Start()
    {
        startFollow = true;



        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    
    void Update()
    {
        if(target != null)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer < followDuration && startFollow)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                startFollow = false;
                breakTimer += Time.deltaTime;
            }

            if (breakTimer > breakDuration && !startFollow)
            {
                startFollow = true;
                waitTimer = 0;
                breakTimer = 0;
            }

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject == player)
        {
            Debug.Log("Collided with player");
            CharacterController controller = player.GetComponent<CharacterController>();
            controller.TakeDamage(damage);
        }
    }


    public void TakeDamage(int damage)
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;

        Debug.Log("Current health: " + health);
    }

    public EnemyType GetEnemyType()
    {
        return enemytype;
    }
}
