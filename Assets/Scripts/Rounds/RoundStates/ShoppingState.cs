using UnityEngine;

public class ShoppingState : RoundBaseState
{
    public override void EnterState(RoundManager roundManager)
    {
        roundManager.shop.ChangeShop();
    }
    public override void UpdateState(RoundManager roundManager)
    {
        if (Input.GetKeyDown("space"))
        {
            ExitState(roundManager);
            roundManager.SwitchState(roundManager.fightingState);
        }
    }
    protected override void ExitState(RoundManager roundManager)
    {
        roundManager.shop.ChangeShop();
    }
}
