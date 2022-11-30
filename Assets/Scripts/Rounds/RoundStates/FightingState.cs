using UnityEngine;

public class FightingState : RoundBaseState
{
    public override void EnterState(RoundManager roundManager)
    {
        roundManager.enemySpawnerManager.StartSpawning(roundManager.roundCounter);
    }
    public override void UpdateState(RoundManager roundManager)
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            ExitState(roundManager);
            roundManager.SwitchState(roundManager.shoppingState);
        }
    }
    protected override void ExitState(RoundManager roundManager)
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().StopSlowTime();
    }
}
