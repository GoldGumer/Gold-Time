using UnityEngine;

public class FightingState : BaseState
{
    public override void EnterState(GameObject Object)
    {
        Object.GetComponent<RoundManager>().enemySpawnerManager.StartSpawning(Object.GetComponent<RoundManager>().roundCounter);
    }
    public override void UpdateState(GameObject Object)
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && GameObject.FindGameObjectWithTag("Enemy Spawner Manager").GetComponent<EnemySpawnerManager>().GetEnemiesToSpawnCount() <= 0)
        {
            ExitState(Object);
            Object.GetComponent<RoundManager>().SwitchState(Object.GetComponent<RoundManager>().peacefulState);
        }
    }
    protected override void ExitState(GameObject Object)
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().StopSlowTime();
    }
}
