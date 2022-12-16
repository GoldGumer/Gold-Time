using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int roundCounter;
    private BaseState roundState;
    public FightingState fightingState = new FightingState();
    public PeacefulState peacefulState = new PeacefulState();
    public ShoppingState shoppingState = new ShoppingState();
    public ShopController shop;
    public EnemySpawnerManager enemySpawnerManager;


    private void Start()
    {
        roundState = peacefulState;
        roundState.EnterState(gameObject);
    }

    private void Update()
    {
        Debug.Log(roundState.ToString());
        roundState.UpdateState(gameObject);
    }

    public void SwitchState(BaseState nextState)
    {
        roundState = nextState;
        roundState.EnterState(gameObject);
    }

    public BaseState GetRoundState()
    {
        return roundState;
    }
}
