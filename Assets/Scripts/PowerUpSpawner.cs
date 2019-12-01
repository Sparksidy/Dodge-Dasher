using System.Collections;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    
    public GameObject treasure;
    public Vector3 rangeToSpawn;
    public float PointsToPowerUp = 50f;

    private CharacterController player;
    private AudioManager.AudioManager audiomanager;
    private bool boxInstantiated = false;
    private float currentScore;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
        currentScore = player.GetScore();
        audiomanager = AudioManager.AudioManager.m_instance;
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.GetScore() % PointsToPowerUp) < Mathf.Epsilon && !boxInstantiated)
        {
            if (player.GetScore() == 0.0f)
                return;

            if(audiomanager)
                audiomanager.PlaySFX("TreasureSpawn");

            InstantiateTreasureBox();

            boxInstantiated = true;

            currentScore = player.GetScore();
        }

        if (currentScore < player.GetScore())
            boxInstantiated = false;

    }

    private void InstantiateTreasureBox()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-rangeToSpawn.x, rangeToSpawn.x), Random.Range(-rangeToSpawn.y, rangeToSpawn.y), 1);
        Debug.Log("SpawnPoistion is: " + spawnPosition);
        Instantiate(treasure, spawnPosition, gameObject.transform.rotation);
    }

}
