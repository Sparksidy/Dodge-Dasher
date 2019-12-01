using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{

    public GameObject Target;

    private Rigidbody2D rb;
    public float speed = 10;
    public float rotateSpeed = 20;

    private AudioManager.AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Enemy");
        rb = GetComponent<Rigidbody2D>();

        audioManager = AudioManager.AudioManager.m_instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Target != null)
        {
            Vector2 direction = (Vector2)Target.transform.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If hit enemy destroy the enemy and the missile
        if(collision.tag == "Enemy")
        {
            if (audioManager)
                audioManager.PlaySFX("MissileHit");
            collision.GetComponent<EnemyFollow>().PlayDeathAnim();
            Destroy(collision.gameObject, collision.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length - 0.25f);
            Destroy(gameObject);
        }
    }




}
