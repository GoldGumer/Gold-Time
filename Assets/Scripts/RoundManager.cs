using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int currentRound = 0;
    private GameObject shop;
    private bool startRound = false;
    private bool isShoppingPhase = true;
    private bool stopRound = false;

    // Start is called before the first frame update
    void Start()
    {
        shop = GameObject.FindGameObjectWithTag("Shop");
    }

    void Update()
    {
        GameObject[] arrayOfEnemies = { };
        arrayOfEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (arrayOfEnemies.Length <= 0 && !isShoppingPhase) stopRound = true;

        if (Input.GetKeyDown("space") && isShoppingPhase)
        {
            startRound = true;
            isShoppingPhase = false;
        }

        if (startRound)
        {
            GameObject.FindGameObjectWithTag("Enemy Spawner").GetComponent<EnemySpawner>().StartSpawning(currentRound);
            shop.GetComponent<ShopController>().ChangeShop();
            startRound = false;
        }
        else if (stopRound)
        {
            shop.GetComponent<ShopController>().ChangeShop();
            currentRound++;
            stopRound = false;
            isShoppingPhase = true;
        }
    }
}
