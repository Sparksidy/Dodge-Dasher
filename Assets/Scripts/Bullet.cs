using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float Bulletlife;
    public int PerBulletDamage = 25;
    public Animator anim;

    public GameObject Target;

    bool moveBullet = true;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");

        if(Target)
        {
            if(moveBullet)
            {
                Vector2 direction = Target.GetComponent<Transform>().position - transform.position;
                direction.Normalize();
                rb.velocity = direction * speed;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy(gameObject, Bulletlife);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterController player = collision.GetComponent<CharacterController>();

            if(player)
            {
                player.TakeDamage(PerBulletDamage);

                moveBullet = false;
                rb.velocity = Vector2.zero;
                anim.Play("Bullet_Destroy");
                Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
            }
        }

        if(collision.tag == "Wall")
        {
            moveBullet = false;
            rb.velocity = Vector2.zero;
            anim.Play("Bullet_Destroy");
            Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
        }

    }



}
