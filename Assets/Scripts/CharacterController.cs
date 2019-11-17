using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;

    public GameObject bulletPrefab;
    public GameObject[] powerUpsPrefabs;

    public Joystick joystick;

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
    private int cherrypickups = 0;

    [System.NonSerialized]
    public bool increaseStamina;

    [SerializeField]
    GameObject playerGhost;

    AudioSource source;


    void Start()
    {
        dashTime = startDashtime;
        Cursor.visible = true;
        increaseStamina = false;

        source = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        #if UNITY_STANDALONE
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        #endif

        #if UNITY_IOS
            movement.x = joystick.Horizontal;
            movement.y = joystick.Vertical;
        #endif

    #if UNITY_STANDALONE
        if (Input.GetKeyDown(KeyCode.Space) && !dashing && Time.time > nextDash && StaminaBarUI.stamina > 10)
        {
            dashing = true;
            nextDash = Time.time + dashRate;
            source.Play();
        }
    #endif

    #if UNITY_IOS
         if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(1);
            Debug.Log("Touch Input detected");
            if(touch.position.x > Screen.width / 2)
            {
                Debug.Log("Right Touch");
                 if (!dashing && Time.time > nextDash && StaminaBarUI.stamina > 10)
                {
                    Debug.Log("Dashing");
                    dashing = true;
                    nextDash = Time.time + dashRate;
                    source.Play();
                }
            }
        }
    #endif

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement != Vector2.zero)
        {
            isMoving = true;
            
        }
        else
            isMoving = false;

        PlayerPrefs.SetInt("score", (int)score);

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
        ++cherrypickups;

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

    public int GetCherryPickups()
    {
        return cherrypickups;
    }

}

