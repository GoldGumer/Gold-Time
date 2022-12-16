using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject basicEnemy;
    private float spawnTime = 0f;
    private bool isSpawning = false;
    private int nextSpawner = 0;
    private EnemySpawner[] enemySpawners;
    private int nextEnemy = 0;
    private GameObject[] enemiesToSpawn;
    private int round;


    private void Start()
    {
        enemySpawners = new EnemySpawner[4];
        int i = 0;
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("EnemySpawner"))
        {
            enemySpawners[i] = gameObject.GetComponent<EnemySpawner>();
            i++;
        }
        enemiesToSpawn = new GameObject[0];
    }
    void FixedUpdate()
    {
        if (isSpawning && spawnTime <= 0f && GetEnemiesToSpawnCount() > 0)
        {
            enemySpawners[nextSpawner].SpawnEnemy(enemiesToSpawn[nextEnemy]);
            enemiesToSpawn[nextEnemy] = null;
            spawnTime = spawnRate;
            nextEnemy++;
            nextSpawner++;
            nextSpawner %= 4;
        }
        else if (enemiesToSpawn.Length <= 0)
        {
            isSpawning = false;
        }
        spawnTime -= Time.deltaTime;
    }

    public void StartSpawning(int round)
    {
        isSpawning = true;
        this.round = round;
        enemiesToSpawn = new GameObject[round*10];
        for (int i = 0; i < round*10; i++)
        {
            enemiesToSpawn[i] = basicEnemy;
        }
        nextEnemy = 0;
    }

    public int GetEnemiesToSpawnCount()
    {
        int i = 0;
        foreach (var item in enemiesToSpawn)
        {
            if (item != null) i++;
        }
        return i;
    }
}
