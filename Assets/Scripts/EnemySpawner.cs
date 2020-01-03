using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public Vector3 rangeToSpawn;
    public GameObject enemyShoot;

    public float timebetweenSpawn;
    public int maxEnemyAtATime = 3;

    private int randObjectIndex;
    private float currentTimer;
    private float totalTime;

    
    void Start()
    {
        currentTimer = 0;
        totalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        totalTime += Time.deltaTime;

        float enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount < maxEnemyAtATime && currentTimer > timebetweenSpawn)
        {
            GenerateEnemy();
            currentTimer = 0;
        }

        if(totalTime > 25)
        {
            InstantiateShootingEnemy();
        }
    }

    private void InstantiateShootingEnemy()
    {
        AudioManager.AudioManager.m_instance.PlayMusic("BG_2");
        Vector3 spawnPosition = new Vector3(Random.Range(-rangeToSpawn.x, rangeToSpawn.x), Random.Range(-rangeToSpawn.y, rangeToSpawn.y), 1);

        Instantiate(enemyShoot, spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

        totalTime = 0;
    }

    private void GenerateEnemy()
    {
        int size = EnemyPrefabs.Length;

        randObjectIndex = Random.Range(1, size + 1);

        Vector3 spawnPosition = new Vector3(Random.Range(-rangeToSpawn.x, rangeToSpawn.x), Random.Range(-rangeToSpawn.y, rangeToSpawn.y), 1);

        Instantiate(EnemyPrefabs[randObjectIndex - 1], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
    }

}
