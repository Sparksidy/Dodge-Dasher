using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnLeastWait;
    public float spawnMostWait;
    public int startWait;
    public int maxSpawner;


    int randEnemy;
    int currEnemyCount;

    void Start()
    {
        StartCoroutine(waitSpawner());
        currEnemyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait); 
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds (startWait);
        
        while(currEnemyCount < maxSpawner)
        {
            
            randEnemy = Random.Range(0, enemies.Length - 1);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), 1);
            Instantiate(enemies[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            currEnemyCount++;

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
