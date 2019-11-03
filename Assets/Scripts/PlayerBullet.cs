using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float Bulletlife;
    public int PerBulletDamage = 10;
    Vector2 moveDirection;
    EnemyFollow target;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyFollow>();
        if(target)
        {
            moveDirection = (target.transform.position - transform.position).normalized;
            rb.velocity = moveDirection * speed;
            Debug.Log("The velocity is: " + rb.velocity);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, Bulletlife);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy)
            {
                enemy.TakeDamage(PerBulletDamage);
                Destroy(gameObject);
            }
        }
    }



}
