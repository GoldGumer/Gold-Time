using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    private float spawnTime = 0f;
    private bool isSpawning = false;
    private EnemySpawner[] enemySpawners;
    private List<GameObject> enemiesToSpawn = new List<GameObject>();
    private int round;


    private void Start()
    {
        enemySpawners = new EnemySpawner[4];
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Enemy Spawner"))
        {
            int i = 0;
            enemySpawners[i] = gameObject.GetComponent<EnemySpawner>();
        }
    }
    void FixedUpdate()
    {
        if (isSpawning && spawnTime <= 0f && enemiesToSpawn.Count > 0)
        {

            spawnTime = spawnRate;
        }
        else if (enemiesToSpawn.Count <= 0) isSpawning = false;
        spawnTime -= Time.deltaTime;
    }

    public void StartSpawning(int round)
    {
        isSpawning = true;
        this.round = round;
    }
}
