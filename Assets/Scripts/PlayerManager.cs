using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float runningMultiplier;
    [SerializeField] private float meleeAttackRange;

    private float threshold = 0.2f;
    private bool alive = true;
    private bool running;
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetAxis("Run") > threshold)
        {
            movementSpeed *= runningMultiplier;
            running = true;
        }
        else
        {
            running = false;
        }
    }

    void FixedUpdate()
    {
        if (alive)
        {
            //Movement
            if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
            {
                transform.position += (Vector3.right * Input.GetAxisRaw("Horizontal") * movementSpeed + Vector3.up * Input.GetAxisRaw("Vertical") * movementSpeed);
            }
            if (Input.GetAxisRaw("Run") > threshold && !running)
            {
                movementSpeed *= runningMultiplier;
                running = true;
            }
            else if (Input.GetAxisRaw("Run") < threshold && running)
            {
                movementSpeed /= runningMultiplier;
                running = false;
            }

            //Combat
            Vector2 pointToRotateTo = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            Transform transformHit = Physics2D.Raycast(transform.position, pointToRotateTo, meleeAttackRange, 9).transform;
            Debug.Log(transformHit.gameObject.name);
            if (transformHit.gameObject.CompareTag("Enemy"))
            {
                pointToRotateTo = new Vector2(transformHit.position.x, transformHit.position.y);
            }
            transform.rotation = Quaternion.Euler(0, 0, (Mathf.Rad2Deg * Mathf.Atan2(pointToRotateTo.y - transform.position.y, pointToRotateTo.x - transform.position.x)) - 90f);
        }
    }
}
