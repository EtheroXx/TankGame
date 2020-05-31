using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankSpawn : MonoBehaviour
{


    public GameObject enemyTank;
    public Transform spawnLocation_1;
    public Transform spawnLocation_2;
    public Transform spawnLocation_3;
    public Transform spawnLocation_4;
    public Transform spawnLocation_5;

    float spawnDelay = 5.0f;
    float spawnTimer = 5.0f;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        int enemyTankCount = GameObject.FindGameObjectsWithTag("EnemyTank").Length;

        if (enemyTankCount < 5)
        {
            if (spawnTimer <= 0)
            {
                int randomSpawn = Random.Range(1, 5);

                if (randomSpawn == 1)
                {
                    spawnTimer = spawnDelay;
                    spawnEnemyTank_1();
                }

                if (randomSpawn == 2)
                {
                    spawnTimer = spawnDelay;
                    spawnEnemyTank_2();
                }

                if (randomSpawn == 3)
                {
                    spawnTimer = spawnDelay;
                    spawnEnemyTank_3();
                }

                if (randomSpawn == 4)
                {
                    spawnTimer = spawnDelay;
                    spawnEnemyTank_4();
                }

                if (randomSpawn == 5)
                {
                    spawnTimer = spawnDelay;
                    spawnEnemyTank_5();
                }
            }
        }
    }

    void spawnEnemyTank_1()
    {
        Instantiate(enemyTank, spawnLocation_1.position, spawnLocation_1.rotation);
    }

    void spawnEnemyTank_2()
    {
        Instantiate(enemyTank, spawnLocation_2.position, spawnLocation_2.rotation);
    }

    void spawnEnemyTank_3()
    {
        Instantiate(enemyTank, spawnLocation_3.position, spawnLocation_3.rotation);
    }

    void spawnEnemyTank_4()
    {
        Instantiate(enemyTank, spawnLocation_4.position, spawnLocation_4.rotation);
    }

    void spawnEnemyTank_5()
    {
        Instantiate(enemyTank, spawnLocation_5.position, spawnLocation_5.rotation);
    }


}