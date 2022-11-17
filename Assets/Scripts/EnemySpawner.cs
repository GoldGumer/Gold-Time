using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    private float nextSpawn = 0f;
    private bool isSpawning = false;
    private GameObject[][] enemiesToSpawn = { };

    void FixedUpdate()
    {
        if (isSpawning && nextSpawn <= 0f && enemiesToSpawn.Length > 0)
        {
            nextSpawn = spawnRate;
        }
        else if (enemiesToSpawn.Length <= 0) isSpawning = false;
        nextSpawn -= Time.deltaTime;
    }

    public void StartSpawning(int round)
    {
        isSpawning = true;
    }
}
