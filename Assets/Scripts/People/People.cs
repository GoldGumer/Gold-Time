using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public abstract class People : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected int goldCount;
    [SerializeField] protected int damage;

    protected const float threshold = 0.2f;

    protected abstract void Move();
    protected abstract void UpdateLookDirection();
    protected abstract void OnDeath();

    public void ChangeHealth(int healthDiff)
    {
        health += healthDiff;
    }

    public int GetHealth() { return health; }
    //Update is only should be used by people class and not any of the children
    private void Update()
    {
        if (health <= 0)
        {
            OnDeath();
            Destroy(gameObject);
        }
        UpdateLookDirection();
        Move();
    }
}
