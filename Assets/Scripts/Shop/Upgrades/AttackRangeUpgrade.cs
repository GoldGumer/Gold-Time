using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeUpgrade : BaseUpgrade
{
    public AttackRangeUpgrade(Player _player) : base(_player) { }

    public override void Setup()
    {
        cost = 30;
        change = 0.5f;
    }

    public override void OnBuy()
    {
        if (player.GetGold() >= cost)
        {
            player.ChangeGold(-cost);
            player.meleeAttackRange += change;
        }
    }
}
