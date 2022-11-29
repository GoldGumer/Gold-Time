using UnityEngine;

public abstract class RoundBaseState
{
    public abstract void EnterState(RoundManager roundManager);
    public abstract void UpdateState(RoundManager roundManager);
    protected abstract void ExitState(RoundManager roundManager);
}
