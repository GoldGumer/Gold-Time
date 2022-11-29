using UnityEngine;

public class FightingPhase : RoundBaseState
{
    public override void EnterState(RoundManager roundManager)
    {
        roundManager.enemySpawner.StartSpawning(roundManager.roundCounter);
    }
    public override void UpdateState(RoundManager roundManager)
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            ExitState(roundManager);
            roundManager.SwitchState(new ShoppingState());
        }
    }
    protected override void ExitState(RoundManager roundManager)
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().StopSlowTime();
    }
}
