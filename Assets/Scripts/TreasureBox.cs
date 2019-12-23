using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject[] PowerUpsPrefabs;
    public Vector3 rangeToSpawn;
    public GameObject treasureBoxPickupEffect;

    private int randObjectIndex;
    private AudioManager.AudioManager audiomanager;

    void Start()
    {
        audiomanager = AudioManager.AudioManager.m_instance;
    }

    void InstantiatePowerUp()
    {
        int size = PowerUpsPrefabs.Length;

        randObjectIndex = Random.Range(1, size + 1);

        Vector3 spawnPosition = new Vector3(Random.Range(-rangeToSpawn.x, rangeToSpawn.x), Random.Range(-rangeToSpawn.y, rangeToSpawn.y), 1);

        Instantiate(PowerUpsPrefabs[randObjectIndex - 1], spawnPosition , gameObject.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (audiomanager)
                audiomanager.PlaySFX("PowerUpSpawn");
            Instantiate(treasureBoxPickupEffect, transform.position, transform.rotation);

            InstantiatePowerUp();
            Destroy(gameObject);
        }
    }
}
