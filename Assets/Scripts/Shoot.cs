using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float bulletShootInterval = 1.0f;

    public GameObject bulletPrefab;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > bulletShootInterval)
        {
            Instantiate(bulletPrefab, transform.position, gameObject.transform.rotation);

            timer = 0.0f;
        }
    }

    private void OnDisable()
    {
        AudioManager.AudioManager.m_instance.PlayMusic("BG_1");
    }
}
