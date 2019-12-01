using System.Collections;
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
    public int EnemyHitDamage = 30;
    public GameObject playerDamageEffect;


    private float nextDash;
    private float health = 100;
    private float score = 0;
    private Vector2 movement;
    private bool dashing = false;
    private float dashTime;
    private bool isMoving;
    private bool generateNewDashPoint = true;
    private int cherrypickups = 0;
    private AudioManager.AudioManager audioManager;
    private int counterForSpriteFlashes;
    private Color originalColor;

    [System.NonSerialized]
    public bool increaseStamina;

    [SerializeField]
    public GameObject playerGhost;

    AudioSource source;


    void Start()
    {
        Cursor.visible = true;

        dashTime = startDashtime;
        increaseStamina = false;

        source = this.GetComponent<AudioSource>();
        audioManager = AudioManager.AudioManager.m_instance;
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    void HandleIOSMovement()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
    }

    void HandlePCMovement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void HandlePCDash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !dashing && Time.time > nextDash && StaminaBarUI.stamina > 10)
        {
            dashing = true;
            nextDash = Time.time + dashRate;
            source.Play();
        }
    }

    void Update()
    {
        #if UNITY_STANDALONE
            HandlePCMovement();
        #endif

        #if UNITY_IOS
            HandleIOSMovement();
        #endif

        #if UNITY_STANDALONE
            HandlePCDash();
        #endif

        SetAnimatorValues();

        if (movement != Vector2.zero)
            isMoving = true;
        else
            isMoving = false;

        PlayerPrefs.SetInt("score", (int)score);//For saving high scores
    }

    void SetAnimatorValues()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    //Called when the button is pressed in ios
    public void Dash()
    {
        if (!dashing && Time.time > nextDash && StaminaBarUI.stamina > 10)
        {
            dashing = true;
            nextDash = Time.time + dashRate;
            source.Play();
        }

    }

    void FixedUpdate()
    {
        if (!dashing)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            if(playerGhost)
                Instantiate(playerGhost, transform.position, transform.rotation);

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
        if (collision.tag == "HealthPowerUp")
        {
            if (audioManager)
                audioManager.PlaySFX("CherryCollect");
            PickupHealthPowerUp(collision);
        }
        else if(collision.tag == "Enemy")
        {
            if (IsPlayerDashing())
                DamageEnemy(collision);
            if (!IsPlayerDashing())
            {
                Shake shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
                shake.CamShake();
                Handheld.Vibrate();
                DamagePlayer();
            }
                
        }
    }

    void DamagePlayer()
    {
        Instantiate(playerDamageEffect, transform.position, transform.rotation);
        rb.AddForce(Vector3.Normalize(movement) * 1500f);
        SpriteFlashOnDamage();
        TakeDamage(10);
    }

    bool isRunning = false;
    void SpriteFlashOnDamage()
    {
        if (!isRunning)
            StartCoroutine(Flash());
    }

    IEnumerator Flash()
    {
        isRunning = true;
        for(int i =0; i < 4; i++)
        {
            Color tmp = originalColor;
            tmp.a = 0.2f;
            GetComponent<SpriteRenderer>().color = tmp;
            yield return new WaitForSeconds(0.25f);
            GetComponent<SpriteRenderer>().color = originalColor;
            yield return new WaitForSeconds(0.25f);
        }
        GetComponent<SpriteRenderer>().color = originalColor;
        isRunning = false;
    }

    void PickupHealthPowerUp(Collider2D collision)
    {
        health = Mathf.Max(health + 25, 100f);
        Destroy(collision.gameObject);
    }

    void DamageEnemy(Collider2D collision)
    {
        EnemyFollow enemy = collision.GetComponent<EnemyFollow>();
        if (enemy)
        {
           enemy.TakeDamage(EnemyHitDamage);
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

    public int GetPerDashPointValue()
    {
        return perDashPointValue;
    }

}

