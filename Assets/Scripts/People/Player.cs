using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : People
{
    [SerializeField] private float runningSpeed;
    [SerializeField] private float meleeAttackRange;
    [SerializeField] private float meleeAttackCooldown;
    [SerializeField] private float slowMultiplier;
    [SerializeField] private float slowScale;
    [SerializeField] private int slowCost;
    [SerializeField] private float slowCostCooldown;

    private float slowCostTimeToNext;
    private bool isSlowing = false;

    // 2^LayerNO where LayerNO = 9 cause Enemy is the 9th layer
    const int enemyLayer = 512;

    //Inheritance from people class
    protected override void Move()
    {
        float speed;

        if (Input.GetAxisRaw("Run") >= threshold) speed = runningSpeed;
        else speed = movementSpeed;

        if (isSlowing) speed *= slowMultiplier;

        transform.position += (Vector3.right * Input.GetAxis("Horizontal") + Vector3.up * Input.GetAxis("Vertical")) * speed * Time.unscaledDeltaTime;
    }
    protected override void UpdateLookDirection()
    {
        Vector3 pointToRotateTo = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        if (Input.GetAxisRaw("Fire2") >= threshold)
        {
            Transform transformHit = Physics2D.Raycast(transform.position, pointToRotateTo - transform.position, meleeAttackRange, enemyLayer).transform;
            if (transformHit != null && transformHit.gameObject.CompareTag("Enemy"))
            {
                pointToRotateTo = new Vector2(transformHit.position.x, transformHit.position.y);
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Rad2Deg * Mathf.Atan2(transform.position.y - pointToRotateTo.y, transform.position.x - pointToRotateTo.x)) + 90f);
    }
    protected override void OnDeath()
    {
        Application.Quit();
    }

    //Implementations specific to player class
    private void Start()
    {
        ChangeGold(0);
    }
    private void Attack()
    {
        Vector3 pointLookingAt = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        if (Input.GetAxisRaw("Fire2") >= threshold && Input.GetAxisRaw("Fire1") >= threshold)
        {
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position, pointLookingAt - transform.position, meleeAttackRange, enemyLayer);
            if (rayHit)
            {
                Vector3 newPos = rayHit.transform.position;
                rayHit.transform.gameObject.GetComponent<Enemy>().ChangeHealth(-damage);
                transform.position = newPos;
            }
        }
    }
    public void ChangeGold(int goldDiff)
    {
        goldCount += goldDiff;
        FindObjectOfType(typeof(Canvas)).GameObject().gameObject.transform.Find("Gold Count").GetComponent<TMP_Text>().text = "Gold Count:\n" + goldCount;
    }
    private void SlowTime()
    {
        if (isSlowing && Input.GetKeyDown(KeyCode.E))
        {
            StopSlowTime();
        }
        else if (!isSlowing && Input.GetKeyDown(KeyCode.E) && GameObject.Find("Round Manager").GetComponent<RoundManager>().GetRoundState() == GameObject.Find("Round Manager").GetComponent<RoundManager>().fightingState)
        {
            StartSlowTime();
        }
        if (isSlowing && slowCostTimeToNext <= 0f)
        {
            ChangeGold(-slowCost);
            slowCostTimeToNext = slowCostCooldown;
        }
        slowCostTimeToNext -= Time.unscaledDeltaTime;
    }
    public void StartSlowTime()
    {
        Time.timeScale = slowScale;
        isSlowing = true;
    }
    public void StopSlowTime()
    {
        Time.timeScale = 1f;
        isSlowing = false;
        slowCostTimeToNext = 0f;
    }
    private void LateUpdate()
    {
        SlowTime();
        Attack();
    }
}
