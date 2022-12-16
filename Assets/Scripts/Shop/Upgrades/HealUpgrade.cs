using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUpgrade : BaseUpgrade
{
    public HealUpgrade(Player _player) : base(_player) { }
    public override void Setup()
    {
        cost = 50;
        change = 1;
    }

    public override void OnBuy()
    {
        if (player.GetGold() >= cost && player.GetHealth() < 3)
        {
            player.ChangeGold(-cost);
            player.ChangeHealth((int)change);
        }
    }
}
