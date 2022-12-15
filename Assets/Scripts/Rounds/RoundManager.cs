using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public int roundCounter;
    private RoundBaseState roundState;
    public FightingState fightingState = new FightingState();
    public ShoppingState shoppingState = new ShoppingState();
    public ShopController shop;
    public EnemySpawnerManager enemySpawnerManager;


    private void Start()
    {
        roundState = new ShoppingState();
        roundState.EnterState(this);
    }

    private void Update()
    {
        roundState.UpdateState(this);
    }

    public void SwitchState(RoundBaseState nextState)
    {
        roundState = nextState;
        roundState.EnterState(this);
    }

    public RoundBaseState GetRoundState()
    {
        return roundState;
    }
}
