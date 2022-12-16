using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCooldownUpgrade : BaseUpgrade
{
    public AttackCooldownUpgrade(Player _player) : base(_player) { }

    public override void Setup()
    {
        cost = 60;
        change = 0.5f;
    }

    public override void OnBuy()
    {
        if (player.GetGold() >= cost)
        {
            player.ChangeGold(-cost);
            player.meleeAttackResetTimer -= change;
        }
    }
}
