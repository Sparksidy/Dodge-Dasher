using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public Vector3 rangeToSpawn;

    public float timebetweenSpawn;

    private int randObjectIndex;
    private float currentTimer;

    
    void Start()
    {
        currentTimer = 0;
        GenerateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;


        float enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        

        if (enemyCount < 3 && currentTimer > timebetweenSpawn)
        {
            GenerateEnemy();
            currentTimer = 0;
        }
         
    }

    private void GenerateEnemy()
    {
        int size = EnemyPrefabs.Length;

        randObjectIndex = Random.Range(0, size - 1);

        Debug.Log("The index is: " + size);

        Vector3 spawnPosition = new Vector3(Random.Range(-rangeToSpawn.x, rangeToSpawn.x), Random.Range(-rangeToSpawn.y, rangeToSpawn.y), 1);

        Instantiate(EnemyPrefabs[randObjectIndex], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        
    }

}
