using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public GameObject bulletPrefab;
    public GameObject[] powerUpsPrefabs;

    public Vector2 powerUpsSpawnPositionsRange;

    public float moveSpeed;
    public float startDashtime;
    public float dashSpeed;
    public float dashRate;
    public int perDashPointValue;


    private float nextDash;
    private float health = 100;
    private float score = 0;
    private Vector2 movement;
    private bool dashing = false;
    private float dashTime;
    private bool isDashing;
    private bool isMoving;
    private bool generateNewDashPoint = true;

    [System.NonSerialized]
    public bool increaseStamina;

    [SerializeField]
    GameObject playerGhost;


    void Start()
    {
        dashTime = startDashtime;
        Cursor.visible = false;
        increaseStamina = false;
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && !dashing && Time.time > nextDash && StaminaBarUI.stamina > 10)
        {
            dashing = true;
            nextDash = Time.time + dashRate;
            
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement != Vector2.zero)
        {
            isMoving = true;
            
        }
        else
            isMoving = false;

    }

    void FixedUpdate()
    {
        if (!dashing)
        {
            //Movement in all directions normally
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            GameObject ghost = Instantiate(playerGhost, transform.position, transform.rotation);
            if (dashTime <= 0)
            {
                dashTime = startDashtime;
                rb.velocity = Vector2.zero;
                dashing = false;
            }
            else
            {
                dashTime -= Time.deltaTime;
                rb.velocity = movement * dashSpeed;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("Health OVERRR");
            FindObjectOfType<GameManager>().EndGame();
            Destroy(gameObject);
        }
    }

    public void Score()
    {
        score += perDashPointValue;

        DashBarUI.dashPoints += perDashPointValue;
    }

    private void GeneratePowerUp()
    {
        int size = powerUpsPrefabs.Length;

        int random = Random.Range(0, size);

        Vector3 spawnPosition = new Vector3(Random.Range(-powerUpsSpawnPositionsRange.x, powerUpsSpawnPositionsRange.x), Random.Range(-powerUpsSpawnPositionsRange.y, powerUpsSpawnPositionsRange.y), 1);

        Instantiate(powerUpsPrefabs[random], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Health bar");
        if (collision.tag == "HealthPowerUp")
        {
            //Give an additional 25 health on health power up
            health = Mathf.Max(health + 25, 100f);

            Destroy(collision.gameObject);
        }
    }

    public void EnableFuelStamina()
    {
        if(!increaseStamina)
            increaseStamina = true;
    }

    public bool IncreaseStamina()
    {
        return increaseStamina;
    }

    public void GenerateNewDashPoint()
    {
        generateNewDashPoint = true;
    }

    public void DoNotGenerateDashPoint()
    {
        generateNewDashPoint = false;
    }

    public bool GetDashPointGeneratorBool()
    {
        return generateNewDashPoint;
    }

    public bool IsPlayerDashing()
    {
        return dashing;
    }

    public bool IsPlayerMoving()
    {
        return isMoving;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetScore()
    {
        return score;
    }


}

