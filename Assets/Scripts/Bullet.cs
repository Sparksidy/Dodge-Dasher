using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float Bulletlife;
    public int PerBulletDamage = 25;

    public GameObject Target;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");

        if(Target)
        {
            Vector2 direction = Target.GetComponent<Transform>().position - transform.position;
            direction.Normalize();
            rb.velocity = direction * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, Bulletlife);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Collided with player");

            CharacterController player = collision.GetComponent<CharacterController>();

            if(player)
            {
                player.TakeDamage(PerBulletDamage);
                Destroy(gameObject);
            }
        }
    }



}
