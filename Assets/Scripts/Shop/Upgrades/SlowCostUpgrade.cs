using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCostUpgrade : BaseUpgrade
{
    public SlowCostUpgrade(Player _player) : base(_player) { }
    public override void Setup()
    {
        cost = 200;
        change = 1;
    }

    public override void OnBuy()
    {
        if (player.GetGold() >= cost && player.slowCost > 1)
        {
            player.ChangeGold(-cost);
            player.slowCost -= (int)change;
        }
    }
}
