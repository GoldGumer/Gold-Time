using UnityEngine;

public abstract class BaseUpgrade
{
    protected int cost;
    protected float change;
    protected Player player;

    // Start is called before the first frame update
    public BaseUpgrade(Player _player)
    {
        player = _player;
        Setup();
    }

    public abstract void Setup();

    public abstract void OnBuy();
}
