using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(GameObject Object);
    public abstract void UpdateState(GameObject Object);
    protected abstract void ExitState(GameObject Object);
}
