using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] PowerUpsPrefabs;
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
        if (DashBarUI.dashPoints == DashBarUI.maxDashPoints)
        {
            Debug.Log("Generating a new Power Up");

            GeneratePowerUp();

            DashBarUI.dashPoints = 0;
        }
    }

    private void GeneratePowerUp()
    {
        int size = PowerUpsPrefabs.Length;

        randObjectIndex = Random.Range(0, size - 1);

        Vector3 spawnPosition = new Vector3(Random.Range(-rangeToSpawn.x, rangeToSpawn.x), Random.Range(-rangeToSpawn.y, rangeToSpawn.y), 1);

        Instantiate(PowerUpsPrefabs[randObjectIndex], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
    }

}
