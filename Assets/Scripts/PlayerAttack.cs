using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour { 

    private float TimeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPosition;

    public LayerMask whatIsEnemies;

    public float attackRange;
    public int Damage;

    public GameObject playerAttackEffect;

    public Animator anim;

    void Update()
    {
            if (TimeBtwAttack <=0)
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    anim.Play("Stan_RollDown");
                    
                    //Instantiate(playerAttackEffect, transform.position, Quaternion.identity);

                    Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
                    for(int i =0; i < enemiesToDamage.Length; i++)
                    {
                        enemiesToDamage[i].GetComponent<EnemyFollow>().TakeDamage(Damage);
                    }
                }
                
                TimeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                TimeBtwAttack -= Time.deltaTime;
            }
    }

     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
