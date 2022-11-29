using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : People
{
    //Inheritance from people class
    protected override void Move()
    {
        transform.position += transform.up * movementSpeed * Time.deltaTime;
    }
    protected override void UpdateLookDirection()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Rad2Deg * Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x)) - 90f);
    }
    protected override void OnDeath()
    {
        GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<Player>().ChangeGold(goldCount);
    }

    //Implementations specific to enemies class
    private void LateUpdate()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) collision.gameObject.GetComponent<Player>().ChangeHealth(-damage);
    }
}
