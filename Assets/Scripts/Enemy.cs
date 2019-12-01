using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemySpeed;
    public float FloatingHeight;
    public GameObject bulletPrefab;
    public float bulletInstantiationRadius = 10.0f;

    bool goingUp = true;
    float bulletTimer = 1.0f;
    private GameObject Player;

    public int health = 100;

    private void Start()
    {
        //Get the player
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(goingUp)
        {
            transform.position += Vector3.up * enemySpeed * Time.deltaTime;

            if(transform.position.y >= FloatingHeight)
            {
                goingUp = false;
            }
        }
        else
        {
            transform.position += Vector3.down * enemySpeed * Time.deltaTime;

            if (transform.position.y <= -FloatingHeight)
            {
                goingUp = true;
            }

        }

        if(bulletTimer <= 0)
        {
            if(Player)
            {
                if (Vector3.Magnitude(Player.transform.position - transform.position) < bulletInstantiationRadius)
                {
                    Instantiate(bulletPrefab, transform.position, transform.rotation);

                    bulletTimer = 1.0f;
                }
                
            }
           
        }

        bulletTimer -= Time.deltaTime;

       

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            
            Destroy(gameObject);
        }
    }


    // Update is called once per frame

}
