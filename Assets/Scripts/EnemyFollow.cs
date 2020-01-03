using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Animator anim;
    public float speed = 2f;
    public float followDuration = 5f;
    public float breakDuration = 2f;
    public int targetDamage = 10;
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

    bool followPlayer = true;

    AudioSource source;

    void Start()
    {
        startFollow = true;

        source = this.GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        targetTransform = player.GetComponent<Transform>();
    }

    void Update()
    {
        if(targetTransform != null)
        {
            if(followPlayer)
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
            if(Vector3.Distance(transform.position, targetTransform.position) > 0.5)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
            }
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

    public void PlayDeathAnim()
    {
        switch (enemytype)
        {
            case EnemyType.EASY:
                Debug.Log("Playing Death Animation");
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
        gameObject.transform.localScale = Vector3.one * 1.25f;
        PlayDeathAnim();
        Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length - deathAnimationDelay);
        /*if(enemytype == EnemyType.HARD)
        {
            AudioManager.AudioManager.m_instance.PlayMusic("BG_1");
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject == player)
        {
            CharacterController controller = player.GetComponent<CharacterController>();
            if(!controller.IsPlayerDashing())
                controller.TakeDamage(targetDamage);
        }*/
    }

    public void TakeDamage(int damage)
    {
        
        Instantiate(bloodEffect, new Vector3(transform.position.x, transform.position.y + (float)1.15f, transform.position.z)  , Quaternion.identity);
        followPlayer = false;
        source.Play();
        SpriteFlash();
        health -= damage;
    }

    void SpriteFlash()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        Color currColor = sprite.color;
        sprite.color = Color.red;
        StartCoroutine(WaitForOneSecond(currColor));
    }

    IEnumerator WaitForOneSecond(Color color)
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(1f);
        followPlayer = true;
    }

    public EnemyType GetEnemyType()
    {
        return enemytype;
    }
}
