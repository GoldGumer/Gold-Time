using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{
    private AttackRangeUpgrade attRUpgrade;
    private AttackCooldownUpgrade attCDpgrade;
    private HealUpgrade healUpgrade;
    private SlowCostUpgrade slowCUpgrade;

    private void Start()
    {
        attRUpgrade = new AttackRangeUpgrade(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>());
        attCDpgrade = new AttackCooldownUpgrade(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>());
        healUpgrade = new HealUpgrade(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>());
        slowCUpgrade = new SlowCostUpgrade(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>());
        Debug.Log(attRUpgrade);
        Debug.Log(attCDpgrade);
        Debug.Log(healUpgrade);
        Debug.Log(slowCUpgrade);
    }

    public void BuyAttackRange()
    {
        attRUpgrade.OnBuy();
    }
    public void BuyAttackCooldown()
    {
        attCDpgrade.OnBuy();    
    }
    public void BuyHeal()
    {
        healUpgrade.OnBuy();
    }
    public void BuySlowCost()
    {
        slowCUpgrade.OnBuy();
    }
}
