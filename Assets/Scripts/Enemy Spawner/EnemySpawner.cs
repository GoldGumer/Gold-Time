using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, transform.position + 1.5f * transform.right, Quaternion.identity);
    }
}
