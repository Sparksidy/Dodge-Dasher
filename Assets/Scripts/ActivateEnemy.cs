using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{
    public GameObject enemy;
    private void OnEnable()
    {
        EventManager.activateEnemy += EnemyActive;
    }

    private void OnDisable()
    {
        if(GameObject.FindGameObjectWithTag("Enemy"))
            GameObject.FindGameObjectWithTag("Enemy").SetActive(false);
    }   

    void EnemyActive()
    {
        if (!GameObject.FindGameObjectWithTag("Enemy"))
            Instantiate(enemy, new Vector3(0, 0, 0), transform.rotation);
        else
            enemy.SetActive(true);

        EventManager.activateEnemy -= EnemyActive;
    }
}
