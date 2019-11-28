using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Animator anim;
    public float speed = 2f;
    public float followDuration = 5f;
    public float breakDuration = 2f;
    public int damage = 10;
    public int health = 50;
    public float deathAnimationDelay = 0.25f;
    public enum EnemyType
    {
        EASY = 0,
        MEDIUM,
        HARD,
        TOTAL
    }
    public EnemyType enemytype;
    public GameObject bloodEffect;


    private bool startFollow;
    private Transform targetTransform;
    private GameObject player;
    private float breakTimer;
    private float waitTimer;

    void Start()
    {
        startFollow = true;

        player = GameObject.FindGameObjectWithTag("Player");
        targetTransform = player.GetComponent<Transform>();
    }

    void Update()
    {
        if(targetTransform != null)
        {
            MoveTowardsPlayer();

            if (health <= 0)
            {
                DestroyEnemy();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        waitTimer += Time.deltaTime;

        if (waitTimer < followDuration && startFollow)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
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
    }

    private void PlayDeathAnim()
    {
        switch (enemytype)
        {
            case EnemyType.EASY:
                anim.Play("BaseEnemyDeath");
                break;
            case EnemyType.MEDIUM:
                anim.Play("BaseEnemyDeath");
                break;
            case EnemyType.HARD:
                anim.Play("HardEnemyDeath");
                break;
        }
    }

    private void DestroyEnemy()
    {
        PlayDeathAnim();
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length - deathAnimationDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            CharacterController controller = player.GetComponent<CharacterController>();
            controller.TakeDamage(damage);
        }
    }

    public void TakeDamage(int damage)
    {
        //Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
    }

    public EnemyType GetEnemyType()
    {
        return enemytype;
    }
}
