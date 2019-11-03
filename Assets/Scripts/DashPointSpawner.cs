using System.Collections;
using UnityEngine;

public class DashPointSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawnRandomly;
    public Vector3 rangeToSpawn;

    private int randObjectIndex;
    private CharacterController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetDashPointGeneratorBool())
        {
            player.DoNotGenerateDashPoint();
            randObjectIndex = Random.Range(0, objectsToSpawnRandomly.Length - 1);
            Vector3 spawnPosition = new Vector3(Random.Range(-rangeToSpawn.x, rangeToSpawn.x), Random.Range(-rangeToSpawn.y, rangeToSpawn.y), 1);
            Instantiate(objectsToSpawnRandomly[randObjectIndex], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

        }
    }
}
