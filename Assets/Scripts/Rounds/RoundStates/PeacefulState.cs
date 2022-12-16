using UnityEngine;

public class PeacefulState : BaseState
{
    public override void EnterState(GameObject Object)
    {
        Object.GetComponent<RoundManager>().shop.ChangeShop();
    }
        
    public override void UpdateState(GameObject Object)
    {
        if (Object.GetComponent<RoundManager>().shop.isAccessedByPlayer) Object.GetComponent<RoundManager>().SwitchState(Object.GetComponent<RoundManager>().shoppingState);
        if (Input.GetKeyDown("space"))
        {
            ExitState(Object);
            Object.GetComponent<RoundManager>().roundCounter++;
            Object.GetComponent<RoundManager>().SwitchState(Object.GetComponent<RoundManager>().fightingState);
        }
    }
    protected override void ExitState(GameObject Object)
    {
        Object.GetComponent<RoundManager>().shop.ChangeShop();
    }
}